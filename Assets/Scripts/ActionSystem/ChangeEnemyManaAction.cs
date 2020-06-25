public class ChangeEnemyManaAction : AbstractAction
{
    public override void Execute()
    {
        Manager.instance.enemyStats.doMana(Manager.instance.pokemon_enemy.getManaPercentage(), SetDone);
    }
}
