using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CurrencyManager : MonoBehaviour
{
    [field: SerializeField] public Currency baseCurrency { get; private set; }
    public static event Action<Currency> onCurrencyUpdated;
    public static event Action onItemBought;

    private Currency currency;

    private void Start()
    {
        currency = Instantiate(baseCurrency); 
        onCurrencyUpdated?.Invoke(currency);
    }

    private void OnEnable()
    {
        BuildableItemPreview.onWantToBuy += BuyBuildable;
        AvatarItemPreview.onWantToBuy += BuyAvatarItem;
    }

    private void OnDisable()
    {
        BuildableItemPreview.onWantToBuy -= BuyBuildable;
        AvatarItemPreview.onWantToBuy -= BuyAvatarItem;
    }

    private void BuyBuildable(BuildableItem item , int quantity)
    {
        if(CheckHaveEnoughCurrency(item.Price))
        {
            currency.CurrentValue -= item.Price;
            onCurrencyUpdated?.Invoke(currency);
            onItemBought.Invoke();
        }
    }

    private void BuyAvatarItem(AvatarBaseElement item)
    {
        if (CheckHaveEnoughCurrency(item.Price))
        {
            currency.CurrentValue -= item.Price;
            onCurrencyUpdated?.Invoke(currency);
            onItemBought.Invoke();
        }
    }

    private bool CheckHaveEnoughCurrency(int itemPrice)
    {
        if(currency.currentValue - itemPrice < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
