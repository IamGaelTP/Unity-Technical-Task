using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildableItem))]
public class BuildableItemEditor : Editor
{
    /// <summary>
    /// The reference of our Buildable Item.
    /// </summary>
    public BuildableItem buildableItem;

    /// <summary>
    /// Make it available by default
    /// </summary>
    /// 
    private void OnEnable()
    {
        buildableItem = target as BuildableItem;
    }

    /// <summary>
    /// Draw whatever we already have in SO definition and convert the element icon into Texture
    /// and place the image just under our default inspector.
    /// </summary>
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (buildableItem.PreviewSprite == null)
            return;

        Texture2D texture = AssetPreview.GetAssetPreview(buildableItem.PreviewSprite);
        GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
    }
}