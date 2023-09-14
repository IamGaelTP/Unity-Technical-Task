using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePreview : MonoBehaviour
{
    private List<GameObject> categoryItems = new List<GameObject>();

    private void OnEnable()
    {
        CategoryItemButton.onNewCategorySelected += ResetList;
        CategoryItemButton.onNewSlotItemInstantiated += AddToList;
        ItemSlot.onSlotSelected += ResetSlotsDesign;
    }

    private void ResetList()
    {
        foreach (var item in categoryItems)
        {
            item.DestroyObject();
        }
        categoryItems.Clear();
    }

    private void AddToList(GameObject newItem)
    {
        categoryItems.Add(newItem);
    }

    private void ResetSlotsDesign()
    {
        foreach (var item in categoryItems)
        {
            item.GetComponent<ItemSlot>().ResetToNormalDesign();
        }
    }

    private void OnDisable()
    {
        CategoryItemButton.onNewCategorySelected -= ResetList;
        CategoryItemButton.onNewSlotItemInstantiated -= AddToList; 
        ItemSlot.onSlotSelected -= ResetSlotsDesign;
    }

}
