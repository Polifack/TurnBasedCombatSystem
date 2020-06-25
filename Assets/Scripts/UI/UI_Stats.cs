using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Stats : MonoBehaviour
{
    public UI_StatsBar healthBar;
    public UI_StatsBar manaBar;
    public TextMeshProUGUI pokemonName;
    public UI_StatusEffectIndicator statusEffectIndicator;

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

    public void setPokemonName(PokemonInstance poke)
    {
        pokemonName.text = poke.getSource().poke_name;
    }

    public void setStatusEffect(StatusEffect effect)
    {
        statusEffectIndicator.setStatusEffect(effect);
    }
}
