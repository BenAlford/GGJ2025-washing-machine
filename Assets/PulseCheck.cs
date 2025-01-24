using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseCheck : MonoBehaviour
{
    float timer = 0.15f;
    bool shown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shown)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                shown = false;
                GetComponent<SpriteRenderer>().enabled = false;
                timer = 0.15f;
            }
        }
    }

    public void Pulse()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        shown = true;
    }
}
