using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public enum SpawnSide {Left, Right, Top};

public class Movement : NoteBase
{
    private Vector2 spawn_loc;

    public float time_target;
    private float timer = 0f;

    public bool curveBool = true;


    Vector2 end_loc;

    private void Awake()
    {
        beats_to_travel = 2;
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

