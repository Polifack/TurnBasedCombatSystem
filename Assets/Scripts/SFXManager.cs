﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public void doStatsNegativeAnimation(SpriteRenderer r, float time, Action callback)
    {
        StartCoroutine(doAnimation(Color.blue, r, time, callback));
    }
    public void doStatsPositiveAnimation(SpriteRenderer r, float time, Action callback)
    {
        StartCoroutine(doAnimation(Color.red, r, time, callback));
    }
    public void doHealAnimation(SpriteRenderer r, float time, Action callback)
    {
        StartCoroutine(doAnimation(Color.green, r, time, callback));
    }
    public void doDamageAnimation(SpriteRenderer r, float time, Action callback)
    {
        StartCoroutine(doAnimation(new Color(0, 0, 0, 0), r, time, callback));
    }

    static IEnumerator doAnimation(Color change, SpriteRenderer r, float time, Action callback)
    {
        Color c = r.color;
        r.color = change;
        yield return new WaitForSeconds(time);
        r.color = c;
        yield return new WaitForSeconds(time);

        if (callback!=null)
            callback.Invoke();
    }
}
