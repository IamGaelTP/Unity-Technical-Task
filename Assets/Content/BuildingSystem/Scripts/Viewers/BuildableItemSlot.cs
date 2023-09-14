using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BuildableItemSlot : ItemSlot
{
    public BuildableItem item { get; set; }

    public static event Action<BuildableItem> onBuildableSlotSelected;

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonImage.sprite = buttonDesign.normal;
        lastState = buttonImage.sprite;
    }

    public override void OnClick()
    {
        if(item != null)
        {
            isSelected = true;
            onBuildableSlotSelected?.Invoke(item);
            OnSelection();
        }
    }

    public override void SetDesign()
    {
        base.SetDesign();
        icon.sprite = item.PreviewSprite;
    }



}
