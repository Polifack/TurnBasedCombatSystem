using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCombatFrameAction : AbstractAction
{
    public override void Execute()
    {
        string[] attacksNames = new string[4];
        PokemonAttack[] pokemonAttacks = Manager.instance.pokemon_player.getAttacks();
        int i = 0;
        foreach(PokemonAttack a in pokemonAttacks)
        {
            attacksNames[i] = a.attack_name;
            i++;
        }

        Manager.instance.combatFrame.setButtons(
             attacksNames,
             new Action[4] {
                () => executeAttack(pokemonAttacks[0]),
                () => executeAttack(pokemonAttacks[1]),
                () => executeAttack(pokemonAttacks[2]),
                () => executeAttack(pokemonAttacks[3])});
    }

    void executeAttack(PokemonAttack a)
    {
        Manager.instance.enqueueAction(new ExecuteAttackAction(a, true));
        SetDone();
    }

}
