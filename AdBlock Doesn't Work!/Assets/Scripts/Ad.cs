using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Ad : MonoBehaviour {

    private static ushort numberOfAds = 0;

    private void Start()
    {
        // Changing the name of the ad
        name = "Ad" + numberOfAds++;
    }

    // "Close Button" event
    public void CloseAd()
    {
        Destroy(gameObject);
    }
}
