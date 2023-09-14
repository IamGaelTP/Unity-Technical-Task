                                                        using System;

public class AvatarItemPreview : StoreItemPreview
{
    private AvatarBaseElement currentItemSelected;

    public static event Action<AvatarBaseElement> onAvatarSkinBought;
    public static event Action hidePanels;
    public static event Action returnCallToSlot;

    public override void OnEnable()
    {
        base.OnEnable();
        AvatarItemSlot.onAvatarSlotSelected += UpdateDesign;
    }

    public override void OnClick()
    {
        if(currentItemSelected != null)
        {
            onAvatarSkinBought?.Invoke(currentItemSelected);
        }
        //hidePanels?.Invoke();
    }

    private void UpdateDesign(AvatarBaseElement itemSelected, eAvatarElement type, bool isStoreSlot)
    {
        if(isStoreSlot)
        {
            currentItemSelected = itemSelected;
            itemName.text = currentItemSelected.name;
            itemPrice.text = currentItemSelected.Price;
        }
    }

    public override void OnDisable()
    {
        base.OnDisable();
        AvatarItemSlot.onAvatarSlotSelected -= UpdateDesign;
    }
}
