using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public class BookPageBtn : MonoBehaviour
{
    [field:SerializeField] public ePages buttonPage { get; private set; }

    private Button button;
    public static event Action<ePages> onBookPageSelected;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        onBookPageSelected?.Invoke(buttonPage);
    }

}
