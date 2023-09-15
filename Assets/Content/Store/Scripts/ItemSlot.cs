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

    public virtual void OnEnable()
    {
        button.onClick.AddListener(OnClick);
    }

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public virtual void Start()
    {
        buttonImage.sprite = buttonDesign.normal;
        lastState = buttonImage.sprite;
    }

    public virtual void OnClick() 
    {
        onSlotSelected?.Invoke();
    }

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
    public virtual void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
    }
}
