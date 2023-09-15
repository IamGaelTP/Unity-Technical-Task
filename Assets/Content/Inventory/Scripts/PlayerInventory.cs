using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInventory : MonoBehaviour
{
    [Header("Inventory")]
    public InventoryDatabase inventoryItems;

    public static event Action onInventoryUpdated;


    private void OnEnable()
    {
        AvatarItemPreview.onAvatarSkinBought += AddSkinToInventoy;
        InventoryItemPreview.onSellSkin += RemoveSkinFromInventory;

        NPC.grantInventoryItem += AddBuildableToInventoy;
        BuildableItemPreview.onBuildingBought += AddBuildableToInventoy;
        BuildingPlacer.onBuildablePlaced += RemoveBuildableFromInventory;
        InventoryItemPreview.onSellBuildable += RemoveBuildableFromInventory;
    }

    private void OnDisable()
    {
        AvatarItemPreview.onAvatarSkinBought -= AddSkinToInventoy;
        InventoryItemPreview.onSellSkin -= RemoveSkinFromInventory;
        
        NPC.grantInventoryItem -= AddBuildableToInventoy;
        BuildableItemPreview.onBuildingBought -= AddBuildableToInventoy;
        BuildingPlacer.onBuildablePlaced -= RemoveBuildableFromInventory;
        InventoryItemPreview.onSellBuildable -= RemoveBuildableFromInventory;
    }

    private void AddBuildableToInventoy(BuildableItem newItem, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            inventoryItems.buildables.Add(newItem);
        }
        onInventoryUpdated?.Invoke();
    }

    private void RemoveBuildableFromInventory(BuildableItem newItem)
    {
        inventoryItems.buildables.Remove(newItem);
        onInventoryUpdated?.Invoke();
    }

    private void AddSkinToInventoy(AvatarBaseElement newItem)
    {
        inventoryItems.skins.Add(newItem);
        onInventoryUpdated?.Invoke();
    }

    private void RemoveSkinFromInventory(AvatarBaseElement newItem)
    {
        inventoryItems.skins.Remove(newItem);
        onInventoryUpdated?.Invoke();
    }

}
