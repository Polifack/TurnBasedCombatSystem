public class CheckPlayerVictoryAction : AbstractAction
{
    public override void Execute()
    {
        if (Manager.instance.pokemon_enemy.getHealthPercentage() > 0) Manager.instance.enqueueAction(new EnemyTurnAction());
        else Manager.instance.enqueueAction(new PlayerWinAction());
        SetDone();
    }
}
