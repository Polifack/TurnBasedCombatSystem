using UnityEngine;

public class ChangePlayerHPAction : AbstractAction
{
    float ammount;
    public ChangePlayerHPAction(float _ammount)
    {
        ammount = _ammount;
    }

    public override void Execute()
    {
        if (ammount < 0)
        {
            Manager.instance.pokemon_player.changeHealth(ammount);
            Manager.instance.SFXmanager.doDamageAnimation(Manager.instance.player.GetComponent<SpriteRenderer>(), 0.2f, null);
        }
        else
        {
            Manager.instance.pokemon_player.changeHealth(ammount);
            Manager.instance.SFXmanager.doHealAnimation(Manager.instance.player.GetComponent<SpriteRenderer>(), 0.2f, null);
        }
        Manager.instance.playerStats.doHeal(Manager.instance.pokemon_player.getHealthPercentage(), SetDone);
    }
}
