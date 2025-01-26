using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    private int combo = 0;
    private int highest_combo = 0;

    void Start()
    {
        updateText();
    }

    public void updateText()
    {
        GetComponent<TextMeshProUGUI>().text = "Combo: " + combo.ToString();
    }

    public void addCombo()
    {

        combo++;
        updateText();

        if (combo > highest_combo)
        {
            highest_combo = combo;
        }
    }

    public void resetCombo()
    {
        combo = 0;
        updateText();
    }

    public int getCombo()
    {
        return combo;
    }

    public int getHigh()
    {
        return highest_combo;
    }
}
