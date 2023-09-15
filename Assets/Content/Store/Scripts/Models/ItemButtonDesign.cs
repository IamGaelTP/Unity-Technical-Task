using UnityEngine;

[CreateAssetMenu(fileName = "New Store Item Button Design", menuName = "ScriptableObjects/Store/Create new Item button design")]
public class ItemButtonDesign : ScriptableObject
{
    [field: SerializeField] public Sprite normal { get; private set; }
    [field: SerializeField] public Sprite hovered { get; private set; }
    [field: SerializeField] public Sprite selected { get; private set; }
}
