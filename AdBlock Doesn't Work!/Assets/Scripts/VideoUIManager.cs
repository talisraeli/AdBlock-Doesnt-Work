using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using System;
using UnityEngine.SceneManagement;

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
    private Slider volumeSlider;

    [SerializeField]
    private Sprite[] volumeIcons;

    [Header("Play / Pause")]
    [SerializeField]
    private Image playPauseIcon;
    [SerializeField]
    private Sprite playIcon, pauseIcon;
    private static bool isPlay = false;
    [SerializeField]
    private GameObject blockPanel;

    [Header("Fullscreen")]
    [SerializeField]
    private Sprite[] fullscreenIcons;
    [SerializeField]
    private Image fullscreenButton;

    private void Start()
    {
        float totalTime = (float)video.clip.length;
        // Setting "Time Postion"
        timePosition.maxValue = totalTime;
        // Setting "Total Time"
        this.totalTime.SetText("/" + (totalTime / 60).ToString("0") + ":" + (totalTime / 1 % 60).ToString("00"));

        ChangeVolume(GameManager.Volume);
        volumeSlider.value = GameManager.Volume;

        if(Time.timeScale != 0)
        {
            isPlay = true;
            video.Play();
        }
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
        GameManager.Volume = volume;

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

    // Exit Fullscreen button event
    public void Fullscreen()
    {
        if(Screen.fullScreen)
        {
            Screen.SetResolution(1280, 720, false, Screen.currentResolution.refreshRate);
            fullscreenButton.sprite = fullscreenIcons[0];
        }
        else
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height,
                true, Screen.currentResolution.refreshRate);
            fullscreenButton.sprite = fullscreenIcons[1];
        }
    }

    // Volume button click
    public void MuteOrUnmute()
    {
        if(audio.volume == 0)
        {
            volumeSlider.value = 0.3f;
        }
        else
        {
            volumeSlider.value = 0f;
        }
    }

    // FOR STORY / CREDITS SCENES ONLY \\
    //=================================\\
    public void Skip()
    {
        StartCoroutine(GameObject.FindObjectOfType<LevelLoader>().LoadLevel());
    }

    public void PlayAgain()
    {
        var loader = GameObject.FindObjectOfType<LevelLoader>();
        StartCoroutine(loader.LoadLevel(0));
        GameManager.Score = 0;
    }

    public void OpenWebsite()
    {
        Application.OpenURL("https://ldjam.com/events/ludum-dare/40/adblock-doesnt-work");
    }

}
