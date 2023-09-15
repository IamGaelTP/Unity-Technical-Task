using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AvatarItemSlot : ItemSlot
{
    public AvatarBaseElement item { get; set; }

    public static event Action<AvatarBaseElement, eAvatarElement, bool> onAvatarSlotSelected;

    public eAvatarElement type { get; set; }
    public bool isStoreSlot { get; set; }

    public bool isInventorySlot { get; set; }

    public override void Start()
    {
        base.Start();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        AvatarItemPreview.onAvatarSkinBought += UnlockItem;
    }

    public override void OnDisable()
    {
        base.OnDisable(); 
        AvatarItemPreview.onAvatarSkinBought -= UnlockItem;
    }

    public override void OnClick()
    {
        base.OnClick();
        if (item != null)
        {
            isSelected = true;
            if (isStoreSlot)
            {
                onAvatarSlotSelected?.Invoke(item, type, true);
            }
            else
            {
                onAvatarSlotSelected?.Invoke(item, type, false);
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
        if(item != null)
        {
            if(isStoreSlot)
            {
                button.interactable = true;
            }
            else
            {
                if (item.isUnlocked)
                {
                    button.interactable = true;
                }
                else
                {
                    button.interactable = false;
                }
            }
        }
    }

    private void UnlockItem(AvatarBaseElement item)
    {
        if(this.item.id == item.id)
        {
            item.UnlockItem();
        }
    }
}
