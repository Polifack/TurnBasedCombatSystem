public class ChangeEnemyAfflictionAction : AbstractAction
{
    StatusEffect affliction;

    public ChangeEnemyAfflictionAction(StatusEffect _affliction)
    {
        affliction = _affliction;
    }

    public override void Execute()
    {
        Manager.instance.enqueueAction(new DisplayTextAction("Enemy is now afflicted with " + affliction.effect_name));
        SetDone();
    }
}
