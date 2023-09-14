using UnityEngine;

public class Currency : ScriptableObject
{
    [field: SerializeField] new public string name { get; private set; }
    [field: SerializeField] new public string id { get; private set; }
    [field: SerializeField] new public int currentValue { get; private set; }
    [field: SerializeField] new public Sprite icon { get; private set; }
    private int starterValue = 10000;

    private void Awake()
    {
        currentValue = starterValue;
    }
}
