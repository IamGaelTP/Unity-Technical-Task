using UnityEngine;

[CreateAssetMenu(fileName = "New Character Faces", menuName = "ScriptableObjects/Avatar Customization/ Create new Faces")]
public class DatabaseFaces : ScriptableObject
{
    public BaseFace[] characterFaces;

    public int GetCount()
    {
        return characterFaces.Length;
    }

    public BaseFace GetFaceByIndex(int index)
    {
        return characterFaces[index];
    }

    public BaseFace GetClothByID(string id)
    {
        foreach (var face in characterFaces)
        {
            if (face.ID == id)
            {
                return face;
            }
        }
        return null;
    }
}
