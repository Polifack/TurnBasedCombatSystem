using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Stats : MonoBehaviour
{
    public UI_StatsBar healthBar;
    public UI_StatsBar manaBar;

    public void setHealth(float percentage)
    {
        healthBar.setup(percentage);
    }

    public void setMana(float percentage)
    {
        manaBar.setup(percentage);
    }

    public void doHeal(float percentage, Action callback)
    {
        healthBar.setPercentage(percentage, callback);
    }

    public void doMana(float percentage, Action callback)
    {
        manaBar.setPercentage(percentage, callback);
    }
}
