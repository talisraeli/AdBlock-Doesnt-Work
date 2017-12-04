using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class BackgroundImage : MonoBehaviour
{
    [SerializeField]
    private GameObject image;
    private VideoPlayer player;

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    private void Update()
	{
        if(player.time + 1f >= player.clip.length)
            image.SetActive(true);
        else
            image.SetActive(false);
	}
}
