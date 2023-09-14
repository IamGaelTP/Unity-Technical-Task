using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Avatar Skin Database", menuName = "ScriptableObjects/Avatar Customization/Create new Skin database")]
public class AvatarSkinsDatabase : ScriptableObject
{
    public HairDatabase hairs;
    public ClothesDatabase clothes;
}
