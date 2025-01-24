using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public enum SpawnSide {Left, Right, Top};
    public SpawnSide spawn_side;
    private Vector2 spawn_loc;

    public float time_target;
    private float timer = 0f;

    void Start()
    {
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
    }

    void Update()
    {
        float dt = Time.deltaTime;
        timer += dt;

        if (timer >= time_target)
        {
            transform.position = new Vector2(0f, 0f);
        }

        else 
        {
            transform.position = Vector2.Lerp(spawn_loc, new Vector2(0f, 0f), timer / time_target);
        }
    }
}

