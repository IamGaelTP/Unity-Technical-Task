using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class Buildable
{
    [field: SerializeField] public Tilemap ParentTilemap { get; private set; }
    [field: SerializeField] public BuildableItem BuildableType { get; private set; }
    [field: SerializeField] public GameObject GameObject { get; private set; }
    [field: SerializeField] public Vector3Int Coordinates { get; private set; }

    public Buildable(BuildableItem type, Vector3Int coordinates, Tilemap tilemap, GameObject gameObject = null)
    {
        ParentTilemap = tilemap;
        BuildableType = type;
        Coordinates = coordinates;
        GameObject = gameObject;
    }
}
