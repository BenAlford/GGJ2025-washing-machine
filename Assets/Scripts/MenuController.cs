using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuController : MonoBehaviour
{
    [SerializeField] VideoPlayer intro_video_player;
    [SerializeField] VideoPlayer outro_video_player;
    [SerializeField] VideoPlayer loop_video_player;

    [SerializeField] RawImage intro_image;
    [SerializeField] RawImage outro_image;
    [SerializeField] RawImage loop_image;

    private void Start()
    {
        intro_video_player.loopPointReached += introFinished;
        outro_video_player.loopPointReached += outroFinished;
    }

    public void startGame()
    {
        //start outro
        outro_image.gameObject.SetActive(true);
        outro_video_player.Play();

        //stop loop
        loop_video_player.Stop();        
    }

    public void exitGame()
    {
        Application.Quit();
    }

    void introFinished(VideoPlayer video_player)
    {
        //start loop
        loop_image.gameObject.SetActive(true);
        loop_video_player.Play();
    }

    void outroFinished(VideoPlayer video_player)
    {
        if (moving)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
                SceneManager.LoadScene("timertest");
        }
    }
}
