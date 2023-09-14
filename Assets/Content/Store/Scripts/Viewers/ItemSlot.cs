using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public class ItemSlot : MonoBehaviour
{
    protected Button button;
    public Image icon;
    public Image buttonImage;
    public ItemButtonDesign buttonDesign;
    protected Sprite lastState;
    protected bool isSelected = false;

    public static event Action onSlotSelected;

    private void OnEnable()
    {
        button.onClick.AddListener(OnClick);
    }

    public virtual void OnClick() { }

    public virtual void SetDesign()
    {
        icon.enabled = true;
    }

    public virtual void ResetToNormalDesign()
    {
        isSelected = false;
        buttonImage.sprite = buttonDesign.normal;
        lastState = buttonDesign.normal;
    }

    public virtual void OnNormal()
    {
        if (!isSelected)
            buttonImage.sprite = lastState;
    }

    public virtual void OnHover()
    {
        if (!isSelected)
            buttonImage.sprite = buttonDesign.hovered;
    }

    public virtual void OnSelection()
    {
        buttonImage.sprite = buttonDesign.selected;
        lastState = buttonDesign.selected;
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
    }
}
