using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimatorManager : MonoBehaviour
{ 
    float time_for_beat;
    float timer = 0;

    Animator animator;

    CatState cat_state = CatState.NEUTRAL;

    enum CatState
    {
        HAPPY = 1,
        NEUTRAL = 2,
        ANGRY = 3
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        int bpm = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>().bpm;
        time_for_beat = 1f / ((float)bpm / 60f);
        timer += 0.15f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            bopNeutral();
        }
        timer += Time.deltaTime;
        if (timer > time_for_beat)
        {
            switch (cat_state)
            {
                case CatState.HAPPY:
                    {
                        bopHappy();
                        break;
                    }
            }
            
            timer -= time_for_beat;
        }
    }

    public void bopHappy()
    {
        if (animator != null)
        {
            animator.SetTrigger("BopHappy");
        }
    }

    public void bopNeutral()
    {
        if (animator != null)
        {
            animator.SetTrigger("BopNeutral");
        }
    }

    public void bopAngry()
    {
        if (animator != null)
        {
            animator.SetTrigger("BopAngry");
        }
    }
}
