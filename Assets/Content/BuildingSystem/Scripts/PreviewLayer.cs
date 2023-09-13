using UnityEngine;

public class PreviewLayer : TilemapLayer
{
    [SerializeField] private SpriteRenderer previewRenderer;

    public void ShowPreview(BuildableItem item, Vector3 worldCoords, bool isValid)
    {
        var coords = tilemap.WorldToCell(worldCoords);
        previewRenderer.enabled = true;
        previewRenderer.transform.position = tilemap.CellToWorld(coords) + tilemap.cellSize / 2;
        previewRenderer.sprite = item.previewSprite;
        previewRenderer.color = isValid ? new Color(0, 1, 0, 0.5f) : new Color(1, 0, 0, 0.5f);
    }

    public void ClearPreview()
    {
        previewRenderer.enabled = false;
    }

}
