using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AbstractAction
{
    private bool done = false;

    public abstract void Execute();
    public bool IsDone() { return done;}
    public void SetDone() { done = true;}
}
