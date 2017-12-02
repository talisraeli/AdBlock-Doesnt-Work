using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using System;

public class VideoUIManager : MonoBehaviour {

    [SerializeField]
    private VideoPlayer video;
    [SerializeField]
    private Slider timePosition;
    [SerializeField]
    private TextMeshProUGUI currentTime, totalTime;

    [Header("Audio UI")]
    [SerializeField]
    private Image volumeIcon;
    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private Sprite[] volumeIcons;

    [Header("Play / Pause")]
    [SerializeField]
    private Image playPauseIcon;
    [SerializeField]
    private Sprite playIcon, pauseIcon;
    private static bool isPlay = true;
    [SerializeField]
    private GameObject blockPanel;

    private void Start()
    {
        float totalTime = (float)video.clip.length;
        // Setting "Time Postion"
        timePosition.maxValue = totalTime;
        // Setting "Total Time"
        this.totalTime.SetText("/" + (totalTime / 60).ToString("0") + ":" + (totalTime / 1 % 60).ToString("00"));
    }

    private void Update()
    {
        // Updating UI
        float time = (float)video.time;
        timePosition.value = time;
        currentTime.SetText((time / 60).ToString("0") + ":" + (time / 1 % 60).ToString("00"));
    }

    // Pause / Play button
    public void PlayOrPause()
    {
        if(isPlay)
        {
            Time.timeScale = 0f;
            playPauseIcon.sprite = playIcon;
            video.Pause();
            blockPanel.SetActive(true);
            isPlay = false;
        }
        else
        {
            Time.timeScale = 1f;
            playPauseIcon.sprite = pauseIcon;
            video.Play();
            blockPanel.SetActive(false);
            isPlay = true;
        }
    }

    // Change volume slider
    public void ChangeVolume(float volume)
    {
        audio.volume = volume;

        if(volume <= 0f)
            volumeIcon.sprite = volumeIcons[0];
        else if(volume <= 0.25f)
            volumeIcon.sprite = volumeIcons[1];
        else if(volume <= 0.5f)
            volumeIcon.sprite = volumeIcons[2];
        else if(volume <= 0.75f)
            volumeIcon.sprite = volumeIcons[3];
        else
            volumeIcon.sprite = volumeIcons[4];
    }

}
