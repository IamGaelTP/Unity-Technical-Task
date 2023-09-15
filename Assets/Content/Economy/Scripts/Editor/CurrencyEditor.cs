using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Currency))]
public class CurrencyEditor : Editor
{
    /// <summary>
    /// The reference of our Currency element
    /// </summary>
    public Currency baseElement;

    /// <summary>
    /// Make it available by default
    /// </summary>
    /// 
    private void OnEnable()
    {
        baseElement = target as Currency;
    }

    /// <summary>
    /// Draw whatever we already have in SO definition and convert the element icon into Texture
    /// and place the image just under our default inspector.
    /// </summary>
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (baseElement.icon == null)
            return;

        GUILayout.Space(10f);
        Texture2D texture = AssetPreview.GetAssetPreview(baseElement.icon);
        GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
    }
}