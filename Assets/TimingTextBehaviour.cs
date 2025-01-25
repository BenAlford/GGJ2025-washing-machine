using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimingTextBehaviour : MonoBehaviour
{
    float timer = 0.3f;
    bool active = false;

    public void Activate()
    {
        timer = 0.3f;
        GetComponent<TextMeshProUGUI>().enabled = true;
        active = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                GetComponent<TextMeshProUGUI>().enabled = false;
                active = false;
            }
        }
    }
}
