public class ChangePlayerAfflictionAction : AbstractAction
{
    StatusEffect affliction;

    public ChangePlayerAfflictionAction(StatusEffect _affliction)
    {
        affliction = _affliction;
    }

    public override void Execute()
    {
        Manager.instance.enqueueAction(new DisplayTextAction("Player is now afflicted with " + affliction.effect_name));
        Manager.instance.enqueueAction(new ChangePlayerStatusEffectAction(affliction));
        SetDone();
    }
}
