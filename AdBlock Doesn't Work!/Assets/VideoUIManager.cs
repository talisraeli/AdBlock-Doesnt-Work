using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

[RequireComponent(typeof(CanvasScaler))]
public class VideoUIManager : MonoBehaviour {

    [SerializeField]
    private VideoPlayer video;
    [SerializeField]
    private Slider timePosition;
    [SerializeField]
    private TextMeshProUGUI currentTime, totalTime;

    private void Start()
    {
        float totalTime = (float)video.clip.length;
        timePosition.maxValue = totalTime;
        this.totalTime.SetText("/" + (totalTime / 60).ToString("0") + ":" + (totalTime / 1 % 60).ToString("00"));
        Debug.Log(totalTime);
    }

    private void Update()
    {
        float time = (float)video.time;
        timePosition.value = time;
        currentTime.SetText((time / 60).ToString("0") + ":" + (time / 1 % 60).ToString("00"));
    }

}
