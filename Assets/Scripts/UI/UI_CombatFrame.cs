using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CombatFrame : MonoBehaviour
{
    public UI_CombatMenu combatMenu;
    public UI_TextFrame textFrame;

    public void disableButtonsFrame()
    {
        combatMenu.gameObject.SetActive(false);
        textFrame.setWidthSize(1900f);
    }

    public void enableButtonsFrame()
    {
        combatMenu.gameObject.SetActive(true);
        textFrame.setWidthSize(1400);
    }
    
    public void setCursor()
    {
        combatMenu.setFirstButton();
    }

    public void setButtons(string[] names, Action[] callbacks)
    {
        int i = 0;
        foreach (UI_Button b in combatMenu.buttons)
        {
            b.setText(names[i]); b.setCallback(callbacks[i]);
            i++;
        }
    }


}
