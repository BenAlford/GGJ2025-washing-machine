using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnSide {Left, Right, Top};

public class Movement : MonoBehaviour
{

    public SpawnSide spawn_side;
    private Vector2 spawn_loc;

    public int arrival_bar = 0;
    public int arrival_beat = 0;

    public float time_target;
    private float timer = 0f;
    int beats_to_travel = 2;

    public bool finished = false;

    Vector2 end_loc;

    public void SetArrivalBeat(int current_bar, int current_beat)
    {
        arrival_bar = current_bar;
        arrival_beat = current_beat + beats_to_travel;
        if (arrival_beat > 4)
        {
            arrival_beat -= 4;
            arrival_bar++;
        }
        print("bar: " + arrival_bar.ToString() + " beat: " + arrival_beat.ToString());
    }

    void Start()
    {
        int bpm = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>().bpm;
        time_target  = (1f / ((float)bpm / 60f)) * beats_to_travel;

        float height = Camera.main.orthographicSize * 2;
        float width = height * Camera.main.aspect;

        switch (spawn_side)
        {
            case SpawnSide.Right:
                transform.position = new Vector2(width / 2, 0f);
            break;

            case SpawnSide.Left:            
                transform.position = new Vector2(width / -2, 0f);
            break;
            
            //Top
            default:
                transform.position = new Vector2(0f, height / 2);
            break;
        }

        spawn_loc = transform.position;

        float distance = Vector2.Distance(spawn_loc, new Vector2(0, 0));
        float speed = distance / time_target;
        float extra_distance = ((1f / ((float)bpm / 60f)) / 2) * speed;

        end_loc = -spawn_loc.normalized * extra_distance;
        time_target += ((1f / ((float)bpm / 60f)) / 2);
    }

    void Update()
    {
        float dt = Time.deltaTime;
        timer += dt;

        if (timer >= time_target)
        {
            transform.position = end_loc;
            finished = true;
        }

        else 
        {
            transform.position = Vector2.Lerp(spawn_loc, end_loc, timer / time_target);
        }
    }
}

