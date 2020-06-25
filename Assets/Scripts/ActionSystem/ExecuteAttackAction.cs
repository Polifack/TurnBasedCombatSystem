using System;
using UnityEngine;

public class ExecuteAttackAction : AbstractAction
{
    Attack attack;
    bool isPlayer;
    public ExecuteAttackAction(Attack _attack, bool _isPlayer)
    {
        attack = _attack;
        isPlayer = _isPlayer;
    }
    public override void Execute()
    {
        if (isPlayer)
        {
            //Initial Actions
            //Setup mana, show text, disable buttons and play animation

            Manager.instance.enqueueAction(new HideButtonsFrameAction());
            
            if (Manager.instance.pokemon_player.changeMana(-1 * attack.ManaCost))
            {
                outOfManaPlayer();
                SetDone();
                return;
            }
            Debug.Log(Manager.instance.pokemon_player.getManaPercentage());
            Manager.instance.enqueueAction(new ChangePlayerManaAction());
            Manager.instance.enqueueAction(new AttackAnimationAction(attack.Animation,
                Manager.instance.player.transform, Manager.instance.enemy.transform));
            
            Func<bool> lastDone = null;
            foreach (AbstractAction a in attack.getAttackPlayer())
            {
                lastDone = a.IsDone;
                Manager.instance.enqueueAction(a);
            }
            
            Manager.instance.textFrame.setTextWait(
                "Executing attack " + attack.Name, 
                ()=> Manager.instance.enqueueAction(new CheckPlayerVictoryAction()), 
                lastDone);
            SetDone();
            
        }
        else
        {
            //Initial Actions
            //Setup mana, show text, and play animation

            if (Manager.instance.pokemon_enemy.changeMana(-1 * attack.ManaCost))
            {
                outOfManaEnemy();
                SetDone();
                return;
            }
            Manager.instance.enqueueAction(new ChangeEnemyManaAction());
            Manager.instance.enqueueAction(new AttackAnimationAction(attack.Animation, 
                Manager.instance.enemy.transform, Manager.instance.player.transform));
            
            Func<bool> lastDone = null;
            foreach (AbstractAction a in attack.getAttackEnemy())
            {
                lastDone = a.IsDone;
                Manager.instance.enqueueAction(a);
            }

            Manager.instance.textFrame.setTextWait(
                "Enemy executing attack " + attack.Name, 
                ()=> Manager.instance.enqueueAction(new CheckEnemyVictoryAction()), 
                lastDone);
            SetDone();
        }
    }

    void outOfManaPlayer()
    {
        Manager.instance.enqueueAction(new DisplayTextAction("You have no mana for this action!"));
        Manager.instance.enqueueAction(new ShowButtonsFrameAction());
        Manager.instance.enqueueAction(new ShowCombatFrameAction());
        return;
    }

    void outOfManaEnemy()
    {
        Manager.instance.enqueueAction(new EnemyTurnAction());
    }
}

