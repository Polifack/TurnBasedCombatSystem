public class ChangeEnemyManaAction : AbstractAction
{
    float ammount;
    public ChangeEnemyManaAction(float _ammount)
    {
        ammount = _ammount;
    }

    public override void Execute()
    {
        Manager.instance.pokemon_enemy.changeMana(ammount);
        Manager.instance.enemyStats.doMana(Manager.instance.pokemon_enemy.getManaPercentage(), SetDone);
    }
}
