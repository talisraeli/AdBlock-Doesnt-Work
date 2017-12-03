using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AngryMeter : MonoBehaviour
{

    [SerializeField]
    private Image pointer;
    [SerializeField]
    private CanvasScaler canvas;

    [SerializeField]
    [Range(20, 60)]
    private int fail = 30;

    [SerializeField]
    private TextMeshProUGUI totalScoreTxt, colorMultiTxt, clickMultiText, newPointPrefab;
    [SerializeField]
    private Transform newPointsGroup;

    private byte colorMulti = 1;

    private static AngryMeter angryMeter;

    private void Start()
    {
        angryMeter = this;
        canvas = GetComponentInParent<CanvasScaler>();
    }

    private void Update()
    {
        // Pointer Movement
        pointer.rectTransform.SetPositionAndRotation(
            new Vector3((Mathf.Clamp(Ad.numberOfAds, 0f, fail) * (240f / fail) + 8f) * canvas.scaleFactor,
            pointer.rectTransform.position.y), Quaternion.identity);

        // Setting color multi and click multi
        clickMultiText.SetText("x" + ClickManager.clicksInTheLast2Second.Count);

        float precent = Mathf.Clamp(Ad.numberOfAds, 0f, fail) / fail;

        if(precent <= 0.25f)
        {
            colorMulti = 8;
            colorMultiTxt.color = new Color(0.576f, 1f, 0f);
        }
        else if(precent <= 0.5f)
        {
            colorMulti = 4;
            colorMultiTxt.color = new Color(1f, 0.913f, 0f);
        }
        else if(precent <= 0.75f)
        {
            colorMulti = 2;
            colorMultiTxt.color = new Color(1f, 0.509f, 0f);
        }
        else
        {
            colorMulti = 1;
            colorMultiTxt.color = new Color(1f, 0f, 0f);
        }

        colorMultiTxt.SetText("x" + colorMulti);
    }

    // Add score
    public static void AddScore()
    {
        // Calculating score
        uint score = angryMeter.colorMulti * (uint)ClickManager.clicksInTheLast2Second.Count;
        // Display
        var points = Instantiate(angryMeter.newPointPrefab, Vector3.zero, Quaternion.identity, angryMeter.newPointsGroup);
        points.SetText("+" + score);

        // Fade in and out
        angryMeter.StartCoroutine(Fade(points));

        // Setting Score
        GameManager.Score += score;
        angryMeter.totalScoreTxt.SetText(GameManager.Score.ToString("000000"));
    }

    private static IEnumerator Fade(TextMeshProUGUI points)
    {
        for(float f = 0f; f < 1f; f += 0.2f)
        {
            Color c = points.color;
            c.a = f;
            points.color = c;
            yield return null;
        }
        for(float f = 1f; f >= 0f; f -= 0.025f)
        {
            Color c = points.color;
            c.a = f;
            points.color = c;
            yield return null;
        }

        Destroy(points.gameObject);
    }
}
