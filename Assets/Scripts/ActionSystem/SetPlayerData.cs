using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerData : AbstractAction
{
    public override void Execute()
    {
        Manager.instance.player.GetComponent<SpriteRenderer>().sprite = Manager.instance.pokemon_player.getSource().getImgBack();
        Manager.instance.playerStats.setPokemonName(Manager.instance.pokemon_player);
        SetDone();
    }
}
