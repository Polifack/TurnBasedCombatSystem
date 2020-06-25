using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTextAction : AbstractAction
{
    string content = "";

    public DisplayTextAction(string _content)
    {
        content = _content;
    }

    public override void Execute()
    {
        Manager.instance.textFrame.setText(content, SetDone);
    }
}
