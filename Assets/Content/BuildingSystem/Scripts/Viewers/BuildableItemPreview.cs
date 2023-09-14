using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BuildableItemPreview : MonoBehaviour
{
    private BuildableItem currentItemSelected;

    public TMP_Text itemName;
    public TMP_Text itemPrice;
    public Button itemButton;

    public static event Action<BuildableItem, int> onBuildingBought;
    public static event Action hidePanels;
    public static event Action returnCallToSlot;

    private void OnEnable()
    {
        BuildableItemSlot.onBuildableSlotSelected += UpdateDesign;
        itemButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
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

    private void OnDisable()
    {
        BuildableItemSlot.onBuildableSlotSelected -= UpdateDesign;
        itemButton.onClick.RemoveListener(OnClick);
    }

}
