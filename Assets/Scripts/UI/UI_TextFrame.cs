using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEditor;

public class UI_TextFrameItem
{
    public string content;
    public Func<bool> waitCondition;
    public Action onDone;

    public UI_TextFrameItem(string s, Action c, Func<bool> w)
    {
        content = s;
        waitCondition = w;
        onDone = c;
    }
}
public class UI_TextFrame : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image frame;
    public Image hasMoreText;
    public float speed;

    public Queue<UI_TextFrameItem> textQueue = new Queue<UI_TextFrameItem>();

    private void Awake()
    {
        hasMoreText.enabled = false;
        StartCoroutine(Run());
    }


    //Change size
    public void setWidthSize(float x)
    {
        frame.rectTransform.sizeDelta = new Vector2(x, frame.rectTransform.sizeDelta.y);
    }

    //Add text and callback to queue
    public void setText(string newText, Action callback)
    {
        textQueue.Enqueue(new UI_TextFrameItem(newText, callback, null));
    }

    //Add several lines of text to queue and callback to be executed in the last line
    public void setText(string[] newText, Action callback)
    {
        int l = newText.Length;
        int i = 0;

        foreach(String t in newText)
        {
            Action ondone = null;
            if (i == l) ondone = callback;
          
            textQueue.Enqueue(new UI_TextFrameItem(t, ondone, null));
        }
    }


    //Sets a text and wait for something before allowing to interact
    public void setTextWait(string newText, Action callback, Func<bool> waitCond)
    {
        textQueue.Enqueue(new UI_TextFrameItem(newText, callback, waitCond));
    }

    public void setTextWait(string[] newText, Action callback, Func<bool> waitCond)
    {
        int l = newText.Length;
        int i = 0;

        foreach (String t in newText)
        {
            Action ondone = null;
            Func<bool> waitfor = null;

            if (i == l)
            {
                ondone = callback;
                waitfor = waitCond;
            }

            textQueue.Enqueue(new UI_TextFrameItem(t, ondone, waitfor));
        }
    }

    private IEnumerator Run()
    {
        while (true)
        {
            if (textQueue.Count > 0)
            {
                //Get next element
                text.text = "";
                UI_TextFrameItem item = textQueue.Dequeue();
                
                string newText = item.content;
                Action callback = item.onDone;
                Func<bool> waitCondition = item.waitCondition;

                //Print text
                while (true)
                {
                    text.text += newText[0];
                    newText = newText.Substring(1);
                    if (newText.Length == 0)
                    {
                        break;
                    }
                    yield return new WaitForSeconds(speed);
                }

                //Wait for the wait condition
                if (waitCondition != null)
                {
                    while (!waitCondition())
                    {
                        yield return null;
                    }
                }

                
                //Wait for interaction
                hasMoreText.enabled = true;
                while (!ControllerManager.isInteracting())
                {
                    yield return null;
                }
                
                //Clean and callback
                hasMoreText.enabled = false;
                if (callback != null) callback.Invoke();
                yield return null;
            }
            yield return null;
        }
    }



}
