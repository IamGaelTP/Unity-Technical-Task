                                                        using System;

public class AvatarItemPreview : StoreItemPreview
{
    private AvatarBaseElement currentItemSelected;

    public static event Action<AvatarBaseElement> onWantToBuy;
    public static event Action<AvatarBaseElement> onAvatarSkinBought;
    public static event Action hidePanels;
    public static event Action returnCallToSlot;

    public override void OnEnable()
    {
        base.OnEnable();
        CurrencyManager.onItemBought += OnBought;
        AvatarItemSlot.onAvatarSlotSelected += UpdateDesign;
    }

    public override void OnClick()
    {
        if(currentItemSelected != null)
        {
            onWantToBuy?.Invoke(currentItemSelected);
        }
    }

    private void OnBought()
    {
        onAvatarSkinBought?.Invoke(currentItemSelected);
        ResetDesign();
        //hidePanels?.Invoke();
    }

    private void ResetDesign()
    {
        currentItemSelected = null;
        itemName.text = "??????";
        itemPrice.text = "???";
    }

    private void UpdateDesign(AvatarBaseElement itemSelected, eAvatarElement type, bool isStoreSlot)
    {
        if(isStoreSlot)
        {
            currentItemSelected = itemSelected;
            itemName.text = currentItemSelected.name;
            itemPrice.text = currentItemSelected.Price.ToString();
        }
    }

    public override void OnDisable()
    {
        base.OnDisable(); 
        CurrencyManager.onItemBought -= OnBought;
        AvatarItemSlot.onAvatarSlotSelected -= UpdateDesign;
    }
}
