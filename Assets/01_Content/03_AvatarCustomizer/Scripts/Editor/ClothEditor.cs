using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BaseCloth))]
public class ClotheEditor : Editor
{
    /// <summary>
    /// The reference of our Avatar Base Element.
    /// </summary>
    public BaseCloth baseClothe;

    /// <summary>
    /// Make it available by default
    /// </summary>
    /// 
    private void OnEnable()
    {
        baseClothe = target as BaseCloth;
    }

    /// <summary>
    /// Draw whatever we already have in SO definition and convert the element icon into Texture
    /// and place the image just under our default inspector.
    /// </summary>
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (baseClothe.ICON == null)
            return;

        Texture2D texture = AssetPreview.GetAssetPreview(baseClothe.ICON);
        GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
    }
}
