using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Avatar Skin", menuName = "ScriptableObjects/Avatar Customization/Create new Skin")]
public class AvatarSkin : ScriptableObject
{
    [field: SerializeField] public AvatarBaseElement baseBody { get; private set; }
    [field: SerializeField] public AvatarBaseElement hair { get; private set; }
    [field: SerializeField] public AvatarBaseElement clothes { get; private set; }

    public void NewBody(AvatarBaseElement newElement)
    {
        baseBody = newElement;

    }
    public void NewHair(AvatarBaseElement newElement)
    {
        hair = newElement;
    }

    public void NewClothes(AvatarBaseElement newElement)
    {
        clothes = newElement;
    }
}
