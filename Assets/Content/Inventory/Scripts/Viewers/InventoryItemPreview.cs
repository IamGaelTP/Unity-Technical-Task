using System;
using UnityEngine.UI;

public class InventoryItemPreview : StoreItemPreview
{
    private BuildableItem buildableSelected;
    private AvatarBaseElement skinSelected;

    // On Sell
    public static event Action<BuildableItem> onSellBuildable;
    public static event Action<AvatarBaseElement> onSellSkin;
    public static event Action<int> onSellItem;

    // On Use
    public static event Action<BuildableItem, int> onBuildingUse;
    public static event Action hidePanels;
    public static event Action<AvatarBaseElement, eAvatarElement, bool> onAvatarSkinUse;


    public Button useBtn;


    public override void OnEnable()
    {
        base.OnEnable();
        useBtn.onClick.AddListener(OnUseClick);
        BuildableItemSlot.onBuildableSlotSelected += UpdateBuildableDesign;
        AvatarItemSlot.onAvatarSlotSelected += UpdateAvatarDesign;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        useBtn.onClick.RemoveListener(OnUseClick);
        BuildableItemSlot.onBuildableSlotSelected -= UpdateBuildableDesign;
        AvatarItemSlot.onAvatarSlotSelected -= UpdateAvatarDesign;
    }

    public override void OnClick()
    {
        if (buildableSelected != null)
        {
            SellItem();
        }
        else if (skinSelected != null)
        {
            SellItem();
        }
    }

    private void OnUseClick()
    {
        if (buildableSelected != null)
        {
            hidePanels?.Invoke();
            onBuildingUse?.Invoke(buildableSelected, 1); 
        }
        else if (skinSelected != null)
        {
            if(skinSelected.GetType() == typeof(BaseCloth))
            {
                onAvatarSkinUse?.Invoke(skinSelected, eAvatarElement.CLOTHES, false);
            }
            else if (skinSelected.GetType() == typeof(BaseHair))
            {
                onAvatarSkinUse?.Invoke(skinSelected, eAvatarElement.HAIR, false);
            }
        }

        ResetDesign();
    }

    private void SellItem()
    {
        if (buildableSelected != null)
        {
            buildableSelected.LockItem();
            onSellBuildable?.Invoke(buildableSelected);
            onSellItem?.Invoke(buildableSelected.Price / 2);
        }
        else if (skinSelected != null)
        {
            skinSelected.LockItem();
            onSellSkin?.Invoke(skinSelected);
            onSellItem?.Invoke(skinSelected.Price / 2);
        }

        ResetDesign();
    }

    private void ResetDesign()
    {
        buildableSelected = null;
        itemName.text = "??????";
        itemPrice.text = "???";
    }

    private void UpdateBuildableDesign(BuildableItem itemSelected)
    {
        buildableSelected = itemSelected;
        itemName.text = buildableSelected.name;
        itemPrice.text = (buildableSelected.Price / 2).ToString();
    }

    private void UpdateAvatarDesign(AvatarBaseElement itemSelected, eAvatarElement type, bool isStoreSlot)
    {
        skinSelected = itemSelected;
        itemName.text = skinSelected.name;
        itemPrice.text = (skinSelected.Price / 2).ToString();
    }


}
