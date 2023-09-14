using System;

public class BuildableItemPreview : StoreItemPreview
{
    private BuildableItem currentItemSelected;

    public static event Action<BuildableItem, int> onWantToBuy;
    public static event Action<BuildableItem, int> onBuildingBought;
    public static event Action hidePanels;
    public static event Action returnCallToSlot;

    public override void OnEnable()
    {
        base.OnEnable();
        CurrencyManager.onItemBought += OnBought;
        BuildableItemSlot.onBuildableSlotSelected += UpdateDesign;
    }

    public override void OnClick()
    {
        if (currentItemSelected != null)
        {
            onWantToBuy?.Invoke(currentItemSelected, 1);
        }
    }

    private void OnBought()
    {
        hidePanels?.Invoke();
        onBuildingBought?.Invoke(currentItemSelected, 1);
    }

    private void UpdateDesign(BuildableItem itemSelected)
    {
        currentItemSelected = itemSelected;
        itemName.text = currentItemSelected.Name;
        itemPrice.text = currentItemSelected.Price.ToString(); ;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        CurrencyManager.onItemBought -= OnBought;
        BuildableItemSlot.onBuildableSlotSelected -= UpdateDesign;
    }

}
