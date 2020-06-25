using System;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : Selectable, IDeselectHandler, IEventSystemHandler, IPointerClickHandler,
    IPointerEnterHandler, IPointerExitHandler, ISelectHandler, ISubmitHandler
{
    Image buttonImage;
    TextMeshProUGUI textMeshPro;
    Action callback;

    public Color hoverColor;
    public Color disableColor;
    Color originalColor;

    protected override void Awake()
    {
        base.Awake();

        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        buttonImage = GetComponent<Image>();
        navigation = Navigation.defaultNavigation;

        if (buttonImage != null)
            originalColor = GetComponent<Image>().color;
    }
    public void setText(string _text)
    {
        textMeshPro.text = _text;
    }
    public void setCallback(Action _callback)
    {
        callback = _callback;
    }
    public void setInteractable(bool b)
    {
        interactable = b;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
            callback.Invoke();
    }
    public void OnSubmit(BaseEventData eventData)
    {

            callback.Invoke();

    }
    
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.color = hoverColor;
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.color = originalColor;
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.color = hoverColor;
    }
    public override void OnDeselect(BaseEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.color = originalColor;
    }

}
