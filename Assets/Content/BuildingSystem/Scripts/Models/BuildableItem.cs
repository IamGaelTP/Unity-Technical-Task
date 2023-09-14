using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Building Item", menuName = "ScriptableObjects/Building/Create new Item")]
public class BuildableItem : ScriptableObject
{
    [field: SerializeField] public string Id { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Price { get; private set; }
    [field: SerializeField] public TileBase Tile { get; private set; }
    [field: SerializeField] public Sprite PreviewSprite { get; private set; }
}
