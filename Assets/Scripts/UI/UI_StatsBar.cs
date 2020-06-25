using System;
using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UI_StatsBar : MonoBehaviour
{
    public GameObject content;
    public float speed;
    
    private float _initialWidth;
    private bool _isWorking = false;
    
    private void Awake()
    {
        Vector2 sizeDelta = content.GetComponent<RectTransform>().sizeDelta;
        _initialWidth = sizeDelta.x;
    }

    public void setup(float dx)
    {
        Vector2 sizeDelta = content.GetComponent<RectTransform>().sizeDelta;
        sizeDelta.x = sizeDelta.x * dx;
        
        content.GetComponent<RectTransform>().sizeDelta = sizeDelta;
    }

    public void setPercentage(float dx, Action callback)
    {
        dx = Mathf.Clamp(dx, 0, 1);
        
        if (!_isWorking)
            StartCoroutine(changeFiller(dx, callback));
    }

    private IEnumerator changeFiller(float dx, Action callback)
    {
        Vector2 sizeDelta = content.GetComponent<RectTransform>().sizeDelta;
        float initialValue = sizeDelta.x;
        float finalValue = dx * _initialWidth;
        _isWorking = true;
        while (true)
        {
            sizeDelta.x = (finalValue > initialValue) ? sizeDelta.x + 1f:sizeDelta.x - 1f;   
            content.GetComponent<RectTransform>().sizeDelta = sizeDelta;

            if (finalValue > sizeDelta.x && initialValue >= finalValue ||
                finalValue < sizeDelta.x && initialValue <= finalValue)
            {
                break;
            }

            yield return new WaitForSeconds(speed);
        }
        if (callback!=null)
            callback.Invoke();
        
        _isWorking = false;
        yield return null;
    }
}
