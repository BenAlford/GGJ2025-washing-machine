using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    private int combo = 0;

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
    }

    public void resetCombo()
    {
        combo = 0;
        updateText();
    }
}
