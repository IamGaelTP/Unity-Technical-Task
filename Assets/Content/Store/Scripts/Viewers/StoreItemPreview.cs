using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StoreItemPreview : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemPrice;
    public Button itemButton;

    public virtual void OnEnable()
    {
        itemButton.onClick.AddListener(OnClick);
    }

    public virtual void OnClick() { }

    public virtual void OnDisable()
    {
        itemButton.onClick.RemoveListener(OnClick);
    }
}
