using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eAvatarElement
{
    BASE,
    HAIR,
    CLOTHES
}

[System.Serializable]
public class AvatarBaseElement : ScriptableObject
{
    /// <summary>
    /// The name of th item or element.
    /// </summary>
    

    /// <summary>
    /// A unique identifier of the item or element.
    /// </summary>
    [field: SerializeField] public string id { get; private set; }

    [field: SerializeField] public int Price { get; private set; }

    /// <summary>
    /// The prefab to instance inside the player.
    /// </summary>
    [field: SerializeField] public GameObject prefab { get; private set; }

    /// <summary>
    /// The icon of the item to show on the avatar customization grid
    /// </summary>
    [field: SerializeField] public Sprite icon { get; private set; }

    [field: SerializeField] public bool isUnlocked { get; private set; }

    private AvatarBaseElement defaultValue;

    public void UnlockItem()
    {
        isUnlocked = true;
    }

    public void LockItem()
    {
        isUnlocked = false;
    }

}
