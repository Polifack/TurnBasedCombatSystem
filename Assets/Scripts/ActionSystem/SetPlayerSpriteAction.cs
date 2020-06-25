using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerSpriteAction : AbstractAction
{
    public override void Execute()
    {
        Manager.instance.player.GetComponent<SpriteRenderer>().sprite = Manager.instance.pokemon_player.getSource().getImgBack();
        SetDone();
    }
}
