using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Ad : MonoBehaviour {

    public static ushort numberOfAds { get; private set; }

    private void Start()
    {
        numberOfAds++;
    }

    // "Close Button" event
    public void CloseAd()
    {
        ClickManager.AddCloseClick();
        AngryMeter.AddScore();
        numberOfAds--;
        Destroy(gameObject);
    }
}
