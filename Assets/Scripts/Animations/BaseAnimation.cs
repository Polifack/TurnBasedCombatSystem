using System;
using UnityEngine;

public abstract class BaseAnimation : MonoBehaviour
{
    public Transform target;
    public Transform source;
    public Action callback;
    public void Setup(Transform s, Transform t, Action c)
    {
        target = t;
        source = s;
        callback = c;
    }
    public abstract void Run();
}
