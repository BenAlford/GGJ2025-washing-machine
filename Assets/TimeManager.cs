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
    public GameObject note_pref;
}

public enum HitTiming
{
    Perfect,
    Late,
    Early,
    MissEarly,
    MissLate
}

public class TimeManager : MonoBehaviour
{
    //public GameObject note_pref;
    public GameObject evil_pref;

    public GameObject timing_text_pref;
    public ComboManager combo_manager;

    public List<NoteData> data;

    List<NoteBase> current_notes = new List<NoteBase>();

    int data_index = 0;

    int bar = 1;
    int beat = 1;

    public float beat_timer = 0;
    public float time_for_beat = 0;

    public int bpm;
    bool running = true;

    public TextMeshProUGUI bar_text;
    public TextMeshProUGUI beat_text;
    public GameObject perfect_text;

    public PulseCheck pulser;

    public int perfect_count = 0;
    public int ok_count = 0;
    public int bad_count = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        time_for_beat = 1f / ((float)bpm / 60f);
        print(time_for_beat);
        GetComponent<soundScript>().PlaySongSound();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            { 
            Application.Quit();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            HitTiming timing = HitTiming.Perfect;
            bool next_beat = false;

            if (beat_timer < time_for_beat * 0.1f)
            {

            }
            else if (time_for_beat - beat_timer < time_for_beat * 0.1f)
            {
                next_beat = true;
            }
            else if (beat_timer < time_for_beat * 0.175f)
            {

                timing = HitTiming.Late;
                ok_count++;
            }
            else if (time_for_beat - beat_timer < time_for_beat * 0.175f)
            {
                next_beat = true;

                timing = HitTiming.Early;
                ok_count++;
            }
            else if (beat_timer < time_for_beat / 2)
            {
                timing = HitTiming.MissLate;
                bad_count++;
            }
            else
            {
                timing = HitTiming.MissEarly;
                bad_count++;
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
                    bool not_missed_flag = false;

                    perfect_text.GetComponent<TimingTextBehaviour>().Activate();
                    switch (timing)
                    {
                        case HitTiming.MissEarly:
                            perfect_text.GetComponent<TextMeshProUGUI>().text = "Miss";
                            GetComponent<soundScript>().PlayfailSound();
                            break;

                        case HitTiming.MissLate:
                            perfect_text.GetComponent<TextMeshProUGUI>().text = "Miss";
                            GetComponent<soundScript>().PlayfailSound();
                            break;

                        case HitTiming.Perfect:
                            perfect_text.GetComponent<TextMeshProUGUI>().text = "Perfect";
                            not_missed_flag = true;
                            break;

                        case HitTiming.Late:
                            perfect_text.GetComponent<TextMeshProUGUI>().text = "Late";
                            not_missed_flag = true;
                            break;

                        case HitTiming.Early:
                            not_missed_flag = true;
                            perfect_text.GetComponent<TextMeshProUGUI>().text = "Early";
                            break;

                    }

                    if (not_missed_flag)
                    {
                        if (current_notes[i].evil)
                        {
                            perfect_text.GetComponent<TextMeshProUGUI>().text = "No";
                            GetComponent<soundScript>().PlayfailSound();
                            combo_manager.resetCombo();
                        }
                        else
                        {
                            combo_manager.addCombo();
                            switch (timing)
                            {
                                case HitTiming.Perfect:
                                    GetComponent<soundScript>().PlayPerfectSound();
                                    not_missed_flag = true;
                                    break;

                                case HitTiming.Late:
                                    GetComponent<soundScript>().PlayGoodSound();
                                    not_missed_flag = true;
                                    break;

                                case HitTiming.Early:
                                    not_missed_flag = true;
                                    GetComponent<soundScript>().PlayGoodSound();
                                    break;

                            }
                        }   
                    }    

                    else
                    {
                        combo_manager.resetCombo();
                    }         

                    current_notes[i].Hit(timing);
                    //Destroy(current_notes[i].gameObject);
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

                    GameObject new_note;
                    if (data[data_index].note_pref.GetComponent<Movement>() != null)
                    {
                        bool evil = (Random.Range(0, 4) <= 0);

                        if (!evil)
                        {
                            new_note = Instantiate(data[data_index].note_pref);
                        }
                        else
                        {
                            new_note = Instantiate(evil_pref);
                        }
                    }
                    else
                    {
                        new_note = Instantiate(data[data_index].note_pref);
                    }
                    Debug.Log(new_note.GetComponent<NoteBase>().evil);
                    new_note.GetComponent<NoteBase>().spawn_side = data[data_index].side;
                    new_note.GetComponent<NoteBase>().SetArrivalBeat(bar, beat);
                    current_notes.Add(new_note.GetComponent<NoteBase>());

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
                if (!current_notes[i].evil)
                {
                    combo_manager.resetCombo();
                }                
                Destroy(current_notes[i].gameObject);
                current_notes.RemoveAt(i);
            }
        }

    }
}

