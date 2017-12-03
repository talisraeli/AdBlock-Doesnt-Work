using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class FitResolution : MonoBehaviour {

    private AdsManager adsManager;
    private CanvasScaler canvasScaler;

    private void Start()
    {
        adsManager = GetComponentInChildren<AdsManager>();
        canvasScaler = GetComponent<CanvasScaler>();
    }

    private void Update()
    {
        // Fit the screen for small screens
        if(Screen.height <= 360f || Screen.width <= 640)
        {
            canvasScaler.scaleFactor = 0.5f;
            if(adsManager != null)
                adsManager.adsScale = 0.5f;
        }
        else
        {
            canvasScaler.scaleFactor = 1f;
            if(adsManager != null)
                adsManager.adsScale = 1f;
        }
    }

}
