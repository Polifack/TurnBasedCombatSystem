using System;

public class ShowButtonsFrameAction : AbstractAction
{
    public override void Execute()
    {
        Manager.instance.combatFrame.setButtons(
            new string[4] { "fight", "bag", "team", "run" },
            new Action[4] {
                gotoFight,
                gotoBag,
                gotoTeam,
                gotoRun});

        Manager.instance.combatFrame.enableButtonsFrame();
        Manager.instance.combatFrame.setCursor();
        Manager.instance.combatMenu.makeButtonsInteractable();
               
        Manager.instance.textFrame.setTextWait(
            "What would you do?", null, IsDone);
    }

    private void gotoFight()
    {
        Manager.instance.enqueueAction(new ShowCombatFrameAction());

        SetDone();
    }
    private void gotoBag()
    {
        SetDone();
    }
    private void gotoTeam()
    {
        SetDone();
    }
    private void gotoRun()
    {
        SetDone();
    }
}
