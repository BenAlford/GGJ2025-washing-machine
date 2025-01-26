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

        int finalscore = (GlobalData.perfect_count * 10) + (GlobalData.ok_count * 5) - (GlobalData.bad_count * 5);
        // The variables contained within the GlobalData need to be public?
        DisplayHighScore.text = "Highest Combo: " + GlobalData.combo;

        DisplayPlayerScore.text = "Final Score: " + finalscore;
        DisplayPerfectScore.text = "Perfect Amount: " + GlobalData.perfect_count + "x";
        DisplayGoodScore.text = "Good Amount: " + GlobalData.ok_count + "x";
        DisplayBadScore.text = "Bad Amount: " + GlobalData.bad_count + "x";
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