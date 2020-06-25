using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteAttackAction : AbstractAction
{
    PokemonAttack attack;
    bool isPlayer;
    public ExecuteAttackAction(PokemonAttack _attack, bool _isPlayer)
    {
        attack = _attack;
        isPlayer = _isPlayer;
    }
    public override void Execute()
    {
        if (isPlayer)
        {
            //Initial Actions
            new ChangePlayerManaAction(-1 * attack.mana_cost).Execute();
            Manager.instance.textFrame.setTextWait("Executing attack " + attack.attack_name, null, IsDone);
            Manager.instance.enqueueAction(new HideButtonsFrameAction());
            Manager.instance.enqueueAction(new AttackAnimationAction(attack.animation, Manager.instance.player.transform, Manager.instance.enemy.transform));

            //Attack logic
            if (attack.is_damage)
            {
                Manager.instance.enqueueAction(
                    new ChangeEnemyHPAction(
                        CombatSystem.computeDamage(
                            Manager.instance.pokemon_player, 
                            Manager.instance.pokemon_enemy, 
                            attack)));
            }
            if (attack.is_health)
            {
                Manager.instance.enqueueAction(
                    new ChangePlayerHPAction(attack.health_change));
            }
            if (attack.is_stats)
            {
                if (attack.is_self)
                    foreach (StatChange sc in attack.stats_change)
                    {
                        Manager.instance.enqueueAction(new ChangePlayerStatsAction(sc.stat_name, sc.level_change));
                        Manager.instance.enqueueAction(new DisplayTextAction("Changing stat " + sc.stat_name + " by " + sc.level_change));
                    }
                else
                    foreach (StatChange sc in attack.stats_change)
                    {
                        Manager.instance.enqueueAction(new ChangeEnemyStatsAction(sc.stat_name, sc.level_change));
                        Manager.instance.enqueueAction(new DisplayTextAction("Changing stat " + sc.stat_name + " by " + sc.level_change));
                    }
            }
            if (attack.is_status)
            {
                Manager.instance.enqueueAction(new ChangeEnemyAfflictionAction(attack.status));
            }
            
            //Final actions
            Manager.instance.enqueueAction(new DisplayTextAction("The attack has been executed!"));
            Manager.instance.enqueueAction(new CheckPlayerVictoryAction());
            SetDone();
        }
        else
        {
            //Initial Actions
            new ChangeEnemyManaAction(-1 * attack.mana_cost).Execute();
            Manager.instance.textFrame.setTextWait("Enemy executing attack " + attack.attack_name, null, IsDone);
            Manager.instance.enqueueAction(new AttackAnimationAction(attack.animation, Manager.instance.enemy.transform, Manager.instance.player.transform));

            //Attack logic
            if (attack.is_damage)
            {
                Manager.instance.enqueueAction(
                    new ChangePlayerHPAction(
                        CombatSystem.computeDamage(
                            Manager.instance.pokemon_enemy,
                            Manager.instance.pokemon_player,
                            attack)));
            }
            if (attack.is_health)
            {
                Manager.instance.enqueueAction(
                    new ChangeEnemyHPAction(attack.health_change));
            }
            if (attack.is_stats)
            {
                if (attack.is_self)
                    foreach (StatChange sc in attack.stats_change)
                    {
                        Manager.instance.enqueueAction(new ChangeEnemyStatsAction(sc.stat_name, sc.level_change));
                        Manager.instance.enqueueAction(new DisplayTextAction("Changing stat " + sc.stat_name + " by " + sc.level_change));
                    }
                else
                    foreach (StatChange sc in attack.stats_change)
                    {
                        Manager.instance.enqueueAction(new ChangePlayerStatsAction(sc.stat_name, sc.level_change));
                        Manager.instance.enqueueAction(new DisplayTextAction("Changing stat " + sc.stat_name + " by " + sc.level_change));
                    }
            }
            if (attack.is_status)
            {
                Manager.instance.enqueueAction(new ChangePlayerAfflictionAction(attack.status));
            }
            
            //Final actions
            Manager.instance.enqueueAction(new DisplayTextAction("The attack has been executed!"));
            Manager.instance.enqueueAction(new CheckEnemyVictoryAction());
            SetDone();

        }
    }
}

