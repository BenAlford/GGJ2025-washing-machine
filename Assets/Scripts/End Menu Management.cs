using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenuManagement : MonoBehaviour
{
    public TimeManager timeManager;

    public TextMeshProUGUI DisplayLevel;

    public TextMeshProUGUI DisplayPlayerScore;
    public TextMeshProUGUI DisplayPerfectScore;

    public TextMeshProUGUI DisplayGoodScore;
    public TextMeshProUGUI DisplayBadScore;

    public TextMeshProUGUI DisplayHighScore;
    string LevelName = "TimerTest";

    void Start()
    {
        string HighScore = "10";
        int UserScore = 5;

        DisplayLevel.text = "Level " + GlobalData.level;

        // The variables contained within the timeManager need to be public?
        DisplayHighScore.text = "High Score: " + timeManager.time_for_beat;

        DisplayPlayerScore.text = "Player Score: " + timeManager.beat_timer;
        DisplayPerfectScore.text = "Perfect Amount: x" + timeManager.perfect_count;
        DisplayGoodScore.text = "Good Amount: x" + timeManager.ok_count;
        DisplayBadScore.text = "Bad Amount: x" + timeManager.bad_count;

        Debug.Log(GlobalData.level);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(LevelName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}