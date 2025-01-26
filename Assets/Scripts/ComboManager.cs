using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    private int combo = 0;
    private int highest_combo = 0;

    public GameObject layer1;
    public GameObject layer2;
    public GameObject layer3;
    public GameObject layer4;

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
        if (combo == 5)
        {
            layer1.SetActive(true);
        }
        if (combo == 10)
        {
            layer2.SetActive(true);
        }
        if (combo == 15)
        {
            layer3.SetActive(true);
        }
        if (combo == 20)
        {
            layer4.SetActive(true);
        }


        if (combo > highest_combo)
        {
            highest_combo = combo;
        }
    }

    public void resetCombo()
    {
        combo = 0;
        updateText();

        layer1.SetActive(false);
        layer2.SetActive(false);
        layer3.SetActive(false);
        layer4.SetActive(false);
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
