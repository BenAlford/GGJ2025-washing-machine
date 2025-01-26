using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimatorManager : MonoBehaviour
{ 
    float time_for_beat;
    float timer = 0;

    Animator animator;

    CatState cat_state = CatState.ANGRY;

    public enum CatState
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

                case CatState.NEUTRAL:
                    {
                        bopNeutral();

                        break;
                    }

                case CatState.ANGRY:
                    {
                        bopAngry();

                        break;
                    }
            }
            
            timer -= time_for_beat;
        }
    }

    public void setCatState(CatState new_cat_state)
    {
        cat_state = new_cat_state;
    }

    void bopHappy()
    {
        if (animator != null)
        {
            animator.SetTrigger("BopHappy");
        }
    }

    void bopNeutral()
    {
        if (animator != null)
        {
            animator.SetTrigger("BopNeutral");
        }
    }

    void bopAngry()
    {
        if (animator != null)
        {
            animator.SetTrigger("BopAngry");
        }
    }
}
