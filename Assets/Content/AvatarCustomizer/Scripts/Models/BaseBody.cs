using UnityEngine;


[CreateAssetMenu(fileName = "New Character Body", menuName = "ScriptableObjects/Avatar Customization/Create new Body")]
[System.Serializable]
public class BaseBody : AvatarBaseElement
{
    private eAvatarElement type = eAvatarElement.BASE;
    public eAvatarElement TYPE => type;
}
