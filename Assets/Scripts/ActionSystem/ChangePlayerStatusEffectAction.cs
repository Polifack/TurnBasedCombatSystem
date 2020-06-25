public class ChangePlayerStatusEffectAction : AbstractAction
{
    StatusEffect statusEffect;
    public ChangePlayerStatusEffectAction(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }
    public override void Execute()
    {
        Manager.instance.playerStats.setStatusEffect(statusEffect);
        SetDone();
    }
}
