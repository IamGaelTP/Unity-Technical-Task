using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePreview : MonoBehaviour
{
    private List<GameObject> categoryItems = new List<GameObject>();
    public GameObject skinsPreview;
    public GameObject buildingsSkinsPreview;

    private void OnEnable()
    {
        CategoryItemButton.onNewCategorySelected += ResetList;
        CategoryItemButton.onNewSlotItemInstantiated += AddToList;
        ItemSlot.onSlotSelected += ResetSlotsDesign;
    }

    private void ResetList(eStoreFilter filter)
    {
        foreach (var item in categoryItems)
        {
            item.DestroyObject();
        }
        categoryItems.Clear();

        switch (filter)
        {
            case eStoreFilter.CLOTHES:
                skinsPreview.SetActive(true);
                buildingsSkinsPreview.SetActive(false);
                break;
            case eStoreFilter.BUILDINGS:
                skinsPreview.SetActive(false);
                buildingsSkinsPreview.SetActive(true);
                break;
        }
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
