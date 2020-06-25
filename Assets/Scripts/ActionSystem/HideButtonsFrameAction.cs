public class HideButtonsFrameAction : AbstractAction
{
    public override void Execute()
    {
        Manager.instance.combatFrame.disableButtonsFrame();
        SetDone();
    }
}
