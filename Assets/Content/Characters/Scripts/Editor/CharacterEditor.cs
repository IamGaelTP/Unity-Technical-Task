using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Character))]
public class CharacterEditor : Editor
{
    /// <summary>
    /// The reference of our Character.
    /// </summary>
    /// <summary>
public Character baseElement;

/// Make it available by default
/// </summary>
/// 
private void OnEnable()
{
    baseElement = target as Character;
}

/// <summary>
/// Draw whatever we already have in SO definition and convert the element icon into Texture
/// and place the image just under our default inspector.
/// </summary>
public override void OnInspectorGUI()
{
    base.OnInspectorGUI();

    if (baseElement.portrait == null)
        return;

    GUILayout.Space(10f);
    Texture2D texture = AssetPreview.GetAssetPreview(baseElement.portrait);
    GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
    GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
}
}