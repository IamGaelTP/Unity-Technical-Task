using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BaseFace))]
public class FaceEditor : Editor
{
    /// <summary>
    /// The reference of our Avatar Base Element.
    /// </summary>
    public BaseFace baseElement;

    /// <summary>
    /// Make it available by default
    /// </summary>
    /// 
    private void OnEnable()
    {
        baseElement = target as BaseFace;
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

        GUILayout.Space(10f);
        Texture2D texture = AssetPreview.GetAssetPreview(baseElement.ICON);
        GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
    }
}
