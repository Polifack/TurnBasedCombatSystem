using UnityEngine;

public class ChangePlayerStatsAction : AbstractAction
{
    string stat;
    float ammount;
    
    public ChangePlayerStatsAction(string _stat, float _ammount)
    {
        stat = _stat;
        ammount = _ammount;
    }
    public override void Execute()
    {
        Manager.instance.enqueueAction(new DisplayTextAction("Changing stat " +stat  + " by " +ammount));
        Manager.instance.pokemon_player.changeStat(stat, ammount);
        if (ammount > 0)
            Manager.instance.SFXmanager.doStatsPositiveAnimation(Manager.instance.player.GetComponent<SpriteRenderer>(), 0.5f, SetDone);
        else
            Manager.instance.SFXmanager.doStatsNegativeAnimation(Manager.instance.player.GetComponent<SpriteRenderer>(), 0.5f, SetDone);
    }
}
