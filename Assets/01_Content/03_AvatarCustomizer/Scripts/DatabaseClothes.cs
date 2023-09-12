using UnityEngine;

[CreateAssetMenu(fileName = "New Character Clothes", menuName = "ScriptableObjects/Avatar Customization/ Create new Clothes")]
public class DatabaseClothes : ScriptableObject
{
    public BaseCloth[] characterClothes;

    public int GetCount()
    {
        return characterClothes.Length;
    }

    public BaseCloth GetClothByIndex(int index)
    {
        return characterClothes[index];
    }

    public BaseCloth GetClothByID(string id)
    {
        foreach (var cloth in characterClothes)
        {
            if(cloth.ID == id)
            {
                return cloth;
            }
        }
        return null;
    }
}
