using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinAction : AbstractAction
{
    public override void Execute()
    {
        Manager.instance.textFrame.setTextWait("Player wins!",null, () => false);
    }

}
