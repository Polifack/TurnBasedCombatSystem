using System;
using UnityEngine;

public class ChangePlayerManaAction : AbstractAction
{
    public override void Execute()
    {
        Manager.instance.playerStats.doMana(Manager.instance.pokemon_player.getManaPercentage(), SetDone);
    }
}
