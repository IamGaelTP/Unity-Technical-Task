using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New NPC", menuName = "ScriptableObjects/Characters/Create a new NPC")]
public class NPC : Character
{
    [field: SerializeField] public BuildableItem inventoryItem { get; private set; }
    [field: SerializeField] public int inventoryItemquantity { get; private set; }

    public static event Action<BuildableItem, int> grantInventoryItem;

    public void GrantInventoryItem()
    {
        if(inventoryItem != null)
        {
            grantInventoryItem?.Invoke(inventoryItem, inventoryItemquantity);
        }
    }
}