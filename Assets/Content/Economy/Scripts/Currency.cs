using UnityEngine;

[CreateAssetMenu(fileName = "New Currency", menuName = "ScriptableObjects/Currency/Create new Currency")]
public class Currency : ScriptableObject
{
    [field: SerializeField] new public string name { get; private set; }
    [field: SerializeField] public string id { get; private set; }
    [field: SerializeField, ReadOnlyWhenPlaying] public int currentValue { get; private set; }
    [field: SerializeField] public Sprite icon { get; private set; }
    private int starterValue = 10000;

    private void Awake()
    {
        currentValue = starterValue;
    }

    public int CurrentValue
    {
        get => currentValue;
        set => currentValue = value;
    }

}
