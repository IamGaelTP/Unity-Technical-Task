using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AvatarBaseElement))]
public class AvatarBaseEditor : Editor
{
    /// <summary>
    /// The reference of our Avatar Base Element.
    /// </summary>
    public AvatarBaseElement baseElement;

    /// <summary>
    /// Make it available by default
    /// </summary>
    /// 
    private void OnEnable()
    {
        baseElement = target as AvatarBaseElement;
    }

    /// <summary>
    /// Draw whatever we already have in SO definition and convert the element icon into Texture
    /// and place the image just under our default inspector.
    /// </summary>
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (baseElement.ICON == null)
            return;

        Texture2D texture = AssetPreview.GetAssetPreview(baseElement.ICON);
        GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
    }

}
