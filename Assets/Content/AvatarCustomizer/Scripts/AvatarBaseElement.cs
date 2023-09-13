using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AvatarBaseElement : ScriptableObject
{
    /// <summary>
    /// The name of th item or element.
    /// </summary>
    [SerializeField, ReadOnlyWhenPlaying] new private string name;

    /// <summary>
    /// A unique identifier of the item or element.
    /// </summary>
    [SerializeField, ReadOnlyWhenPlaying] private string id;
    public string ID => id;

    /// <summary>
    /// The prefab to instance inside the player.
    /// </summary>
    [SerializeField, ReadOnlyWhenPlaying] private GameObject prefab;

    /// <summary>
    /// The icon of the item to show on the avatar customization grid
    /// </summary>
    [SerializeField, ReadOnlyWhenPlaying] private Sprite icon;
    public Sprite ICON => icon;
    
}
