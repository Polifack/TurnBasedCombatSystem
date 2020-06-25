using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyData : AbstractAction
{
    public override void Execute()
    {
        Manager.instance.enemy.GetComponent<SpriteRenderer>().sprite = Manager.instance.pokemon_enemy.getSource().getImgFront();
        Manager.instance.enemyStats.setPokemonName(Manager.instance.pokemon_enemy);
        SetDone();
    }
}
