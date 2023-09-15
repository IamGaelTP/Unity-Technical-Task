using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eCharacterType
{
    PLAYABLE,
    NPC
}

[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObjects/Characters/Create a new character")]
public class Character : ScriptableObject
{
    [field: SerializeField] new public string name { get; private set; }
    [field: SerializeField] public Sprite portrait { get; private set; }
    [field: SerializeField] public eCharacterType characterType { get; private set; }

}
