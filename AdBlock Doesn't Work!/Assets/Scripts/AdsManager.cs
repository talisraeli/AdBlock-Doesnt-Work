using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour {

    [SerializeField]
    private Image adPrefab;

    private static Sprite[] adsImages;

    public float adsScale = 1f;

    [SerializeField]
    [Range(0.2f, 1f)]
    private float minDelay = 0.3f;
    [SerializeField]
    [Range(0.6f, 2f)]
    private float maxDelay = 1.3f;

    private void Awake()
    {
        // Setting up the images of the ads
        adsImages = Resources.LoadAll<Sprite>("AdsImages\\");
    }

    private void Start()
    {
        StartCoroutine(CreateAds());
    }

    // Creating ads with a random time span and a random postion
    private IEnumerator CreateAds()
    {
        // Waiting a random delay
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

        // Calculating a random position based on the screen size
        Vector3 adPostion = new Vector3(
            Random.Range(0f, Screen.width - adPrefab.rectTransform.sizeDelta.x * adsScale),
            Random.Range(30f, Screen.height - adPrefab.rectTransform.sizeDelta.y * adsScale));
        adPostion.z = 0f;

        // Creating the ad
        var ad = Instantiate(adPrefab, adPostion, Quaternion.identity, transform);
        ad.sprite = adsImages[(int)Random.Range(0f, adsImages.Length)];

        // Calling this function again (Creates loop)
        StartCoroutine(CreateAds());
    }
}
