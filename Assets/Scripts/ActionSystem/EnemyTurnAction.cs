using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnAction : AbstractAction
{
    public override void Execute()
    {
        Debug.Log("Executing enemy turn");
        PokemonAttack[] attacks = Manager.instance.pokemon_enemy.getAttacks();
        executeAttack(attacks[Random.Range(0, attacks.Length)]);
    }

    void executeAttack(PokemonAttack a)
    {
        Manager.instance.enqueueAction(new ExecuteAttackAction(a, false));
        SetDone();
    }

}
