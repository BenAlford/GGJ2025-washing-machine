using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private bool flipFlop = false;
    public AudioClip clickSound1;
    public AudioClip clickSound2;


    public AudioSource audioSource;

    bool moving = false;
    float timer = 0.5f;

    public void startGame()
    {
        moving = true;
        //SceneManager.LoadScene("timertest");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void MenuButtonSound()
    {
        
        if (flipFlop)
        {
            audioSource.PlayOneShot(clickSound1);

        }
        else
        {
            audioSource.PlayOneShot(clickSound2);
        }
    }

    private void Update()
    {
        if (moving)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
                SceneManager.LoadScene("Level2");
        }
    }

}
