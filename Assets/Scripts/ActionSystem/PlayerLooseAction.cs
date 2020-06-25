using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooseAction : AbstractAction
{
    public override void Execute()
    {
        Manager.instance.textFrame.setTextWait("Player looses!", null, () => false);
    }
}
