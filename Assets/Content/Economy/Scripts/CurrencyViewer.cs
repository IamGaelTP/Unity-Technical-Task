using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyViewer : MonoBehaviour
{
    public Image icon;
    public TMP_Text value;

    private void OnEnable()
    {
        CurrencyManager.onCurrencyUpdated += UpdateDesign;
    }

    private void OnDisable()
    {
        CurrencyManager.onCurrencyUpdated -= UpdateDesign;
    }

    private void UpdateDesign(Currency currency)
    {
        icon.sprite = currency.icon;
        value.text = currency.currentValue.ToString(); ;
    }
}
