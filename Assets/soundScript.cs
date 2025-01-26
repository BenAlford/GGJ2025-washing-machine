using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundScript : MonoBehaviour
{
    public AudioClip successSound;
    public AudioClip failSound;
    public AudioClip goodSound;
    public AudioClip fatalSound;
    public AudioClip winSound;
    public AudioClip Song;


    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPerfectSound()
    {
        audioSource.PlayOneShot(successSound, 3);
    }

    public void PlayfailSound()
    {
        audioSource.PlayOneShot(failSound, 1.5f);
    }

    public void PlayGoodSound()
    {
        audioSource.PlayOneShot(goodSound,8);
    }

    public void PlayFatalSound()
    {
        audioSource.PlayOneShot(fatalSound);
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void PlaySongSound()
    {
        audioSource.PlayOneShot(Song);
    }

}
