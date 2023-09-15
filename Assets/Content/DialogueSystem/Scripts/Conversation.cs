using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Conversation", menuName = "ScriptableObjects/Dialogue System/Create a new conversation")]
public class Conversation : ScriptableObject
{
    [field: SerializeField] public Character speakerLeft { get; private set; }
    [field: SerializeField] public Character speakerRight { get; private set; }

    [field: SerializeField] public Line[] lines { get; private set; }

    public static event Action onConversationFinished;

    public void CallFinishEvent()
    {
        onConversationFinished?.Invoke();
    }
}

[System.Serializable]
public struct Line
{
    public Character character;

    [TextArea(2, 5)]
    public string text;
}
