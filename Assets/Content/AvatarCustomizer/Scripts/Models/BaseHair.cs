using UnityEngine;


[CreateAssetMenu(fileName = "New Character Faces", menuName = "ScriptableObjects/Avatar Customization/ Create new Hair")]
[System.Serializable]
public class BaseHair : AvatarBaseElement
{
    private eAvatarElement type = eAvatarElement.HAIR;
    public eAvatarElement TYPE => type;
}
