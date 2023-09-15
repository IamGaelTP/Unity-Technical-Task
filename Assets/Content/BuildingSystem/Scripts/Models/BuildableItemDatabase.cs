using UnityEngine;

[CreateAssetMenu(fileName = "New Building Database", menuName = "ScriptableObjects/Building/Create new Item database")]
public class BuildableItemDatabase : ScriptableObject
{
    public BuildableItem[] items;
}
