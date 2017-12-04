using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Ad : MonoBehaviour
{
    private float speed;
    private Vector2 min, max;
    private bool isMove, isPostive, isLTR;

    private RectTransform rect;


    private void Start()
    {
        AdsManager.numberOfAds++;

        rect = GetComponent<RectTransform>();

        // Check if the ad moves and calculate direction
        if(Random.Range(0, 2) == 0)
        {
            isMove = true;
            if(Random.Range(0, 2) == 0)
                isPostive = true;
            if(Random.Range(0, 2) == 0)
                isLTR = true;

            min.x = rect.anchoredPosition.x - 200f;
            max.x = rect.anchoredPosition.x + 200f;
            min.y = rect.anchoredPosition.y - 200f;
            max.y = rect.anchoredPosition.y + 200f;

            speed = Random.Range(5f, 36f);
        }
    }

    // Moves the ad
    private void Update()
    {
        if(isMove)
        {
            if(isLTR)
            {
                if(isPostive)
                {
                    if(rect.anchoredPosition.x <= max.x && rect.anchoredPosition.x < Screen.width - 400f)
                        transform.Translate(Vector3.right * speed * Time.deltaTime);
                    else
                        isPostive = false;
                }
                else
                {
                    if(rect.anchoredPosition.x >= min.x && rect.anchoredPosition.x > 0f)
                        transform.Translate(Vector3.left * speed * Time.deltaTime);
                    else
                        isPostive = true;
                }
            }
            else
            {
                if(isPostive)
                {
                    if(rect.anchoredPosition.y <= max.y && rect.anchoredPosition.y < Screen.height - 200f)
                        transform.Translate(Vector3.up * speed * Time.deltaTime);
                    else
                        isPostive = false;
                }
                else
                {
                    if(rect.anchoredPosition.y >= min.y && rect.anchoredPosition.y > 0f)
                        transform.Translate(Vector3.down * speed * Time.deltaTime);
                    else
                        isPostive = true;
                }
            }
        }
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
