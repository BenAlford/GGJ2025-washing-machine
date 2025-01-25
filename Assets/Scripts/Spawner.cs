using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject thing;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Spawn(SpawnSide.Left);
        }
        
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Spawn(SpawnSide.Right);
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            Spawn(SpawnSide.Top);
        }
    }

    private void Spawn(SpawnSide spawn_side)
    {
        GameObject go = Instantiate(thing);
        go.GetComponent<Movement>().spawn_side = spawn_side;
    }
}
