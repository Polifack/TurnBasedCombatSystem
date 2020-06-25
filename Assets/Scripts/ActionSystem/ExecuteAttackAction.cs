using System;

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
            Manager.instance.enqueueAction(new ChangePlayerManaAction(-1 * attack.ManaCost));
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

            Manager.instance.enqueueAction(new ChangeEnemyManaAction(-1 * attack.ManaCost));
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
}

