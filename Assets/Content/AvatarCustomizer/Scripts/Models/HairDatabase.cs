using UnityEngine;

[CreateAssetMenu(fileName = "New Character Faces", menuName = "ScriptableObjects/Avatar Customization/Create new Faces database")]
public class HairDatabase : ScriptableObject
{
    public BaseHair[] characterHairs;

    public int GetCount()
    {
        return characterHairs.Length;
    }

    public BaseHair GetFaceByIndex(int index)
    {
        return characterHairs[index];
    }

    public BaseHair GetClothByID(string id)
    {
        foreach (var face in characterHairs)
        {
            if (face.id == id)
            {
                return face;
            }
        }
        return null;
    }
}
