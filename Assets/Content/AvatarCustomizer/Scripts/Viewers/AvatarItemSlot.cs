using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AvatarItemSlot : ItemSlot
{
    public AvatarBaseElement item { get; set; }

    public static event Action<AvatarBaseElement, bool> onAvatarSlotSelected;

    public bool isStoreSlot { get; set; }

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonImage.sprite = buttonDesign.normal;
        lastState = buttonImage.sprite;
        isStoreSlot = false;
    }

    public override void OnClick()
    {
        if (item != null)
        {
            isSelected = true;
            if (isStoreSlot)
            {
                onAvatarSlotSelected?.Invoke(item, true);
            }
            else
            {
                onAvatarSlotSelected?.Invoke(item, false);
            }
            OnSelection();
        }
    }

    public override void SetDesign()
    {
        base.SetDesign();
        icon.sprite = item.icon;
        CheckSlotUnlocked();
    }

    public void CheckSlotUnlocked()
    {
        if(item.isUnlocked)
        {
            button.interactable = true;
        }
        else if(!item.isUnlocked && isStoreSlot)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
