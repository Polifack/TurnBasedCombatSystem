using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemySpriteAction : AbstractAction
{
    public override void Execute()
    {
        Manager.instance.enemy.GetComponent<SpriteRenderer>().sprite = Manager.instance.pokemon_enemy.getSource().getImgFront();
        SetDone();
    }
}
