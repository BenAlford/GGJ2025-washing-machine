using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBase : MonoBehaviour
{
    public SpawnSide spawn_side;
    public int arrival_bar = 0;
    public int arrival_beat = 0;
    protected int beats_to_travel = 4;
    public bool finished = false;
    public bool evil;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void Hit(HitTiming timing)
    {
        Destroy(gameObject);
    }

    public void SetArrivalBeat(int current_bar, int current_beat, bool faster)
    {
        if (faster)
        {
            beats_to_travel *= 2;
        }
        arrival_bar = current_bar;
        arrival_beat = current_beat + beats_to_travel;
        while (arrival_beat > 4)
        {
            arrival_beat -= 4;
            arrival_bar++;
        }
        //print("bar: " + arrival_bar.ToString() + " beat: " + arrival_beat.ToString());
    }
}
