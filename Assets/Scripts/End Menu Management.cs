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

    public TextMeshProUGUI DisplayPlayerScore;
    public TextMeshProUGUI DisplayPerfectScore;

    public TextMeshProUGUI DisplayGoodScore;
    public TextMeshProUGUI DisplayBadScore;

    public TextMeshProUGUI DisplayHighScore;
    string LevelName = "TimerTest";

    void Start(){
        string HighScore = "10";
        int UserScore = 5;

        int finalscore = (timeManager.perfect_count * 10) + (timeManager.ok_count * 5) - (timeManager.bad_count * 5);
        // The variables contained within the timeManager need to be public?
        DisplayHighScore.text = "Highest Combo Score: " + timeManager.time_for_beat;

        DisplayPlayerScore.text = "Final Score: " + finalscore;
        DisplayPerfectScore.text = "Perfect Amount: " + timeManager.perfect_count + "x";
        DisplayGoodScore.text = "Good Amount: " + timeManager.ok_count + "x";
        DisplayBadScore.text = "Bad Amount: " + timeManager.bad_count + "x";
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