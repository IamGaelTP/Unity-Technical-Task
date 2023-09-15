using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory Database", menuName = "ScriptableObjects/Inventory/Create new Inventory database")]
public class InventoryDatabase : ScriptableObject
{
    public List<BuildableItem> buildables = new List<BuildableItem>();
    public List<AvatarBaseElement> skins = new List<AvatarBaseElement>();

    private void Awake()
    {
        buildables.Clear();
        skins.Clear();
    }


}
