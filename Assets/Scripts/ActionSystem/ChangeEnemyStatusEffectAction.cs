public class ChangeEnemyStatusEffectAction : AbstractAction
{
    StatusEffect statusEffect;
    public ChangeEnemyStatusEffectAction(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }
    public override void Execute()
    {
        Manager.instance.enemyStats.setStatusEffect(statusEffect);
        SetDone();
    }
}
