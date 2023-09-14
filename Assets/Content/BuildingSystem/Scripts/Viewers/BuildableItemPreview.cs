using System;

public class BuildableItemPreview : StoreItemPreview
{
    private BuildableItem currentItemSelected;

    public static event Action<BuildableItem, int> onBuildingBought;
    public static event Action hidePanels;
    public static event Action returnCallToSlot;

    public override void OnEnable()
    {
        base.OnEnable();
        BuildableItemSlot.onBuildableSlotSelected += UpdateDesign;
    }

    public override void OnClick()
    {
        onBuildingBought?.Invoke(currentItemSelected, 1);
        hidePanels?.Invoke();
    }

    private void UpdateDesign(BuildableItem itemSelected)
    {
        currentItemSelected = itemSelected;
        itemName.text = currentItemSelected.Name;
        itemPrice.text = currentItemSelected.Price;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        BuildableItemSlot.onBuildableSlotSelected -= UpdateDesign;
    }

}
