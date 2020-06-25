using UnityEngine;

public class ChangeEnemyStatsAction : AbstractAction
{
    string stat;
    float ammount;

    public ChangeEnemyStatsAction(string _stat, float _ammount)
    {
        stat = _stat;
        ammount = _ammount;
    }
    public override void Execute()
    {
        Manager.instance.pokemon_enemy.changeStat(stat, ammount);
        if (ammount>0)
            Manager.instance.SFXmanager.doStatsPositiveAnimation(Manager.instance.enemy.GetComponent<SpriteRenderer>(), 0.5f, SetDone);
        else
            Manager.instance.SFXmanager.doStatsNegativeAnimation(Manager.instance.enemy.GetComponent<SpriteRenderer>(), 0.5f, SetDone);
    }
}
