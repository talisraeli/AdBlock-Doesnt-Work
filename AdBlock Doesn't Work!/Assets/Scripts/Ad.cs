using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Ad : MonoBehaviour {

    private void Start()
    {
        AdsManager.numberOfAds++;
    }

    // "Close Button" event
    public void CloseAd()
    {
        ClickManager.AddCloseClick();
        AngryMeter.AddScore();
        AdsManager.numberOfAds--;
        Destroy(gameObject);
    }
}
