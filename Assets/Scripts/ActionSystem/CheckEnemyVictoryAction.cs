public class CheckEnemyVictoryAction : AbstractAction
{
    public override void Execute()
    {
        if (Manager.instance.pokemon_player.getHealthPercentage() > 0) Manager.instance.enqueueAction(new ShowButtonsFrameAction());
        else Manager.instance.enqueueAction(new PlayerLooseAction());
        SetDone();
    }
}
