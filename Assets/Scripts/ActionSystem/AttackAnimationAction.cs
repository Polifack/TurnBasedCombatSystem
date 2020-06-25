using System;
using UnityEngine;

public class AttackAnimationAction : AbstractAction
{
    GameObject animation;
    Transform source;
    Transform target;
    public AttackAnimationAction(GameObject _animation, Transform _source, Transform _target)
    {
        animation = _animation;
        source = _source;
        target = _target;
    }
    public override void Execute()
    {
        if (animation != null)
        {
            GameObject animationGameObject = GameObject.Instantiate(animation);
            BaseAnimation animator = animationGameObject.GetComponent<BaseAnimation>();
            animator.Setup(source, target, SetDone);
            animator.Run();
        }
        else
        {
            SetDone();
        }
    }
}
