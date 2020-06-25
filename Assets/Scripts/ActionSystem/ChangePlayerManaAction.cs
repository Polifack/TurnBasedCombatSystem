using UnityEngine;

public class ChangePlayerManaAction : AbstractAction
{
    float ammount;
    public ChangePlayerManaAction(float _ammount)
    {
        ammount = _ammount;
    }

    public override void Execute()
    {
        Manager.instance.pokemon_player.changeMana(ammount);
        Manager.instance.playerStats.doMana(Manager.instance.pokemon_player.getManaPercentage(), SetDone);
    }
}
