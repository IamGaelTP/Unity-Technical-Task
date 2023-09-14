using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Store Database", menuName = "ScriptableObjects/Store/Create new Store database")]
public class StoreItemsDatabase : ScriptableObject
{
    public DatabaseClothes clothes;
    //public PlayerItemsDatabase 
    public BuildableItemDatabase buildings;
}
