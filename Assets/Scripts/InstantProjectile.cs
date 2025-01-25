using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class InstantProjectile : NoteBase
{
    public GameObject throwsuccess;
    public GameObject throwfail;

    float destroy_timer = 0.3f;
    bool start_destroy = false;

    float time_target = 0;
    float timer = 0;
    int bpm = 0;


    private void Awake()
    {
        beats_to_travel = 3;
    }
    // Start is called before the first frame update
    void Start()
    {
        bpm = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>().bpm;

        time_target = (1f / ((float)bpm / 60f)) * beats_to_travel;
        time_target += ((1f / ((float)bpm / 60f)) * 0.15f);

        switch (spawn_side)
        {
            case SpawnSide.Right:
                transform.position = new Vector2(-4.44f, -0.6510549f);
                transform.localScale = new Vector3(-1, 1, 1);
                break;

            case SpawnSide.Left:
                transform.position = new Vector2(4.362289f, -0.6510549f);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (start_destroy)
        {
            destroy_timer -= Time.deltaTime;
            if (destroy_timer < 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > time_target)
            {
                throwfail.SetActive(true);
                start_destroy = true;
            }
        }
    }

    override public void Hit(HitTiming timing)
    {
        if (timing == HitTiming.Perfect || timing == HitTiming.Early || timing == HitTiming.Late)
        {
            throwsuccess.SetActive(true);
            start_destroy = true;
        }
        else if (timing == HitTiming.MissEarly)
        {
            timer -= ((1f / ((float)bpm / 60f)) * 0.15f);
        }

    }
}
