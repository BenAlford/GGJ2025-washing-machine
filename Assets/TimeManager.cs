using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public struct NoteData
{
    public int bar;
    public int beat;
}

public class TimeManager : MonoBehaviour
{
    public List<NoteData> data;
    int data_index = 0;

    int bar = 1;
    int beat = 1;

    float beat_timer = 0;
    float time_for_beat = 0;

    public int bpm;
    bool running = true;

    public TextMeshProUGUI bar_text;
    public TextMeshProUGUI beat_text;
    public TextMeshProUGUI perfect_text;

    public PulseCheck pulser;

    int perfect_count = 0;
    int ok_count = 0;
    int bad_count = 0;


    // Start is called before the first frame update
    void Start()
    {
        time_for_beat = 1f / ((float)bpm / 60f);
        print(time_for_beat);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (beat_timer < 0.15f || time_for_beat - beat_timer < 0.15f )
            {
                perfect_text.text = "perfect";
            }
            else if (beat_timer < 0.25f)
            {
                perfect_text.text = "late";
            }
            else if (time_for_beat - beat_timer < 0.25f)
            {
                perfect_text.text = "early";
            }
            else
            {
                perfect_text.text = "bad";
            }
        }
        beat_timer += Time.deltaTime;
        if (beat_timer > time_for_beat)
        {
            beat++;
            if (beat > 4)
            {
                beat = 1;
                bar++;
            }
            bar_text.text = bar.ToString();
            beat_text.text = beat.ToString();
            beat_timer -= time_for_beat;

            if (running)
            {
                while (data[data_index].bar == bar && data[data_index].beat == beat)
                {
                    pulser.Pulse();

                    data_index++;
                    if (data_index >= data.Count)
                    {
                        running = false;
                        break;
                    }
                }
            }
        }
    }
}
