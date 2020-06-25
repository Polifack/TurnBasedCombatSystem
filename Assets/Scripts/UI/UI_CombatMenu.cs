using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CombatMenu : MonoBehaviour
{
    public UI_Button[] buttons;

    public void setButton(int index, string text, Action callback)
    {
        buttons[index].setText(text);
        buttons[index].setCallback(callback);
    }

    public void makeButtonsInteractable()
    {
        foreach (UI_Button b in buttons)
        {
            b.setInteractable(true);
        }
    }
    public void makeButtonsNonInteractable()
    {
        foreach (UI_Button b in buttons)
        {
            b.setInteractable(false);
        }
    }

    public void setFirstButton()
    {
        buttons[0].Select();
    }
}
