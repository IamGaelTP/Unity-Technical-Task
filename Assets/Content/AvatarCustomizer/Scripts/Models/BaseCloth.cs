using UnityEngine;


[CreateAssetMenu(fileName = "New Character Faces", menuName = "ScriptableObjects/Avatar Customization/Create new Cloth")]
[System.Serializable]
public class BaseCloth : AvatarBaseElement
{
    private eAvatarElement type = eAvatarElement.CLOTHES;
    public eAvatarElement TYPE => type;
}
