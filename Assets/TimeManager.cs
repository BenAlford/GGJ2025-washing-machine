using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public struct NoteData
{
    public int bar;
    public int beat;
    public SpawnSide side;
}

public enum HitTiming
{
    Perfect,
    Late,
    Early,
    Miss
}

public class TimeManager : MonoBehaviour
{
    public GameObject note_pref;

    public List<NoteData> data;

    List<Movement> current_notes = new List<Movement>();

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
            HitTiming timing = HitTiming.Perfect;
            bool next_beat = false;

            if (beat_timer < 0.125f)
            {
                perfect_text.text = "perfect";

            }
            else if (time_for_beat - beat_timer < 0.125f)
            {
                perfect_text.text = "perfect";
                next_beat = true;
            }
            else if (beat_timer < 0.25f)
            {
                perfect_text.text = "late";

                timing = HitTiming.Late;
            }
            else if (time_for_beat - beat_timer < 0.25f)
            {
                perfect_text.text = "early";
                next_beat = true;

                timing = HitTiming.Early;
            }
            else if (beat_timer < time_for_beat / 2)
            {
                perfect_text.text = "bad";
                timing = HitTiming.Miss;
            }
            else
            {
                perfect_text.text = "bad";
                timing = HitTiming.Miss;
                next_beat = true;
            }

            int bar_hit = bar;
            int beat_hit = beat;

            if (next_beat)
            {
                beat_hit++;
                if (beat_hit > 4)
                {
                    beat_hit = 1;
                    bar_hit++;
                }
            }

            print("bar hit: " + bar_hit.ToString() + " beat hit: " + beat_hit.ToString());
            for (int i = current_notes.Count - 1; i >= 0; i--)
            {
                if (current_notes[i].arrival_bar == bar_hit && current_notes[i].arrival_beat == beat_hit)
                {
                    print("YIPPPEEE!!!");
                    Destroy(current_notes[i].gameObject);
                    current_notes.RemoveAt(i);
                }
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
                    GameObject new_note = Instantiate(note_pref);
                    new_note.GetComponent<Movement>().spawn_side = data[data_index].side;
                    new_note.GetComponent<Movement>().SetArrivalBeat(bar, beat);
                    current_notes.Add(new_note.GetComponent<Movement>());

                    data_index++;
                    if (data_index >= data.Count)
                    {
                        running = false;
                        break;
                    }
                }
            }
        }

        for (int i = current_notes.Count - 1; i >= 0; i--)
        {
            if (current_notes[i].finished)
            {
                Destroy(current_notes[i].gameObject);
                current_notes.RemoveAt(i);
            }
        }

    }
}

