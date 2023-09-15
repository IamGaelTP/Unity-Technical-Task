using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryPreview : MonoBehaviour
{
    [Header("Inventory")]
    public InventoryDatabase inventoryItems;
    [field: SerializeField] public GameObject buildableItemSlot { get; private set; }
    [field: SerializeField] public GameObject avatarItemSlot { get; private set; }
    [field: SerializeField] public GameObject slotParent { get; private set; }

    private List<GameObject> inventoryItemsSlots = new List<GameObject>();

    


    private void OnEnable()
    {
        PlayerInventory.onInventoryUpdated += UpdateInventorypreview;
        InstantaiteSlots();
    }

    private void OnDisable()
    {
        PlayerInventory.onInventoryUpdated -= UpdateInventorypreview;
        ClearSlotsList();
    }

    private void UpdateInventorypreview()
    {
        ClearSlotsList();
        InstantaiteSlots();
    }


    private void AddToSlotsList(GameObject obj)
    {
        inventoryItemsSlots.Add(obj);
    }

    private void ClearSlotsList()
    {
        foreach (var item in inventoryItemsSlots)
        {
            item.DestroyObject();
        }
        inventoryItemsSlots.Clear();
    }

    private void InstantaiteSlots()
    {
        foreach (var item in inventoryItems.skins)
        {
            if (item.isUnlocked)
            {
                GameObject obj = Instantiate(avatarItemSlot, slotParent.transform);
                obj.GetComponent<AvatarItemSlot>().item = item;
                obj.GetComponent<AvatarItemSlot>().isStoreSlot = true;
                obj.GetComponent<AvatarItemSlot>().SetDesign();
                AddToSlotsList(obj);
            }
        }
            
        foreach (var item in inventoryItems.buildables)
        {
            GameObject obj = Instantiate(buildableItemSlot, slotParent.transform);
            obj.GetComponent<BuildableItemSlot>().item = item;
            obj.GetComponent<BuildableItemSlot>().SetDesign();
            AddToSlotsList(obj);
        }
    }
}
