using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuController : MonoBehaviour
{
    [SerializeField] VideoPlayer intro_video_player;
    [SerializeField] VideoPlayer outro_video_player;
    [SerializeField] VideoPlayer loop_video_player;
    [SerializeField] VideoPlayer cat_fade_in_video_player;

    private void Start()
    {
        intro_video_player.loopPointReached += introFinished;
    }

    public void startGame()
    {
        SceneManager.LoadScene("timertest");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
    }

    void introFinished(VideoPlayer video_player)
    {
        //stop intro, start loop
        intro_video_player.gameObject.SetActive(false);

        loop_video_player.gameObject.SetActive(true);
        loop_video_player.Play();
    }
}
