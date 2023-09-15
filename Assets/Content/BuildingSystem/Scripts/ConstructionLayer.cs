using System.Collections.Generic;
using UnityEngine;

public class ConstructionLayer : TilemapLayer
{
    private Dictionary<Vector3Int, Buildable> buildables = new Dictionary<Vector3Int, Buildable>();

    public void Build(Vector3 worldCoordinates, BuildableItem item)
    {
        var coords = tilemap.WorldToCell(worldCoordinates);
        var buildable = new Buildable(item, coords, tilemap);

        if(item.Tile != null)
        {
            tilemap.SetTile(coords, item.Tile);
        }

        buildables.Add(coords, buildable);
    }

    public bool IsEmpty(Vector3 worldCoordinates)
    {
        var coords = tilemap.WorldToCell(worldCoordinates);
        return !buildables.ContainsKey(coords) && tilemap.GetTile(coords) == null;
    }

}
