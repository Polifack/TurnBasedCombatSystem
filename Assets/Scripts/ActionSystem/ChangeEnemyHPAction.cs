using System;
using UnityEngine;

public class ChangeEnemyHPAction : AbstractAction
{
    float ammount;
    public ChangeEnemyHPAction(float _ammount)
    {
        ammount = _ammount;
    }

    public override void Execute()
    {
        if (ammount <= 0)
        {
            Manager.instance.pokemon_enemy.changeHealth(ammount);
            Manager.instance.SFXmanager.doDamageAnimation(Manager.instance.enemy.GetComponent<SpriteRenderer>(), 0.2f, null);
        }
        else
        {
            Manager.instance.pokemon_enemy.changeHealth(ammount);
            Manager.instance.SFXmanager.doHealAnimation(Manager.instance.enemy.GetComponent<SpriteRenderer>(), 0.2f, null);
        }
        
        Manager.instance.enemyStats.doHeal(Manager.instance.pokemon_enemy.getHealthPercentage(), SetDone);
    }
}
