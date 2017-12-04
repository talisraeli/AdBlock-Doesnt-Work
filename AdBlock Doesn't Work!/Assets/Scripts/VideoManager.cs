using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private LevelLoader levelLoader;

    [SerializeField]
    private float timeScale = 0f;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        levelLoader =  GameObject.FindObjectOfType<LevelLoader>();
    }

    private void Update()
    {
        if(videoPlayer.time / 1 + 1 >= videoPlayer.clip.length)
        {
            StartCoroutine(levelLoader.LoadLevel(timeScale: timeScale));
        }
    }

}
