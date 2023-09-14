using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public class CategoryItemButton : MonoBehaviour
{
    [Header("Store")]
    public StoreItemsDatabase storeItems;

    [Header("Item")]
    public GameObject slotItemPrefab;
    public GameObject slotParent;
    public eStoreFilter type;

    [Header("UI")]
    public Image buttonImage;
    public ItemButtonDesign buttonDesign;
    private Button button;
    private Sprite lastState;

    public static event Action onNewCategorySelected;
    public static event Action<GameObject> onNewSlotItemInstantiated;

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonImage.sprite = buttonDesign.normal;
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnClick);
        if (type == eStoreFilter.CLOTHES)
        {
            // Simulate Click
            OnClick(); 
            OnSelection();
        }
    }

    private void OnClick()
    {
        onNewCategorySelected?.Invoke();
        InstantiateSlots();
    }

    public void OnNormal()
    {
        buttonImage.sprite = lastState;
    }

    public void OnHover()
    {
        buttonImage.sprite = buttonDesign.hovered;
    }

    public void OnSelection()
    {
        buttonImage.sprite = buttonDesign.selected;
        lastState = buttonDesign.selected;
    }

    private void InstantiateSlots()
    {
        switch (type)
        {
            case eStoreFilter.CLOTHES:
                foreach (var item in storeItems.clothes.characterClothes)
                {
                    GameObject obj = Instantiate(slotItemPrefab, slotParent.transform);
                    onNewSlotItemInstantiated?.Invoke(obj);
                }
                break;
            case eStoreFilter.PLAYER:
                break;
            case eStoreFilter.BUILDINGS:
                foreach (var item in storeItems.buildings.items)
                {
                    GameObject obj = Instantiate(slotItemPrefab, slotParent.transform);
                    obj.GetComponent<BuildableItemSlot>().item = item;
                    obj.GetComponent<BuildableItemSlot>().SetDesign();
                    onNewSlotItemInstantiated?.Invoke(obj);
                }
                break;
            default:
                break;
        }
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
    }

}
