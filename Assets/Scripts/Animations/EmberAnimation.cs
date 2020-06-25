using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class EmberAnimation : BaseAnimation
{
    public GameObject fire;

    public override void Run()
    {
        fire.transform.position = source.transform.position;
        StartCoroutine(run());
    }

    IEnumerator run()
    {
        while (fire.transform.position != target.position)
        {
            fire.transform.position = Vector3.MoveTowards(fire.transform.position, target.position, 0.5f);

            yield return new WaitForFixedUpdate();
        }
        
        Destroy(fire);
        Destroy(gameObject);

        callback.Invoke();
        yield return null;
    }
    
}
