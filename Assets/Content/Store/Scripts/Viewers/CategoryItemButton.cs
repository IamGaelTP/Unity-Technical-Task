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

    public static event Action<eStoreFilter> onNewCategorySelected;
    public static event Action<GameObject> onNewSlotItemInstantiated;

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonImage.sprite = buttonDesign.normal;
    }

    private void OnEnable()
    {
        StorePreview.onResetList += InstantiateClothes;
        button.onClick.AddListener(OnClick);
    }

    private void Start()
    {
        if (type == eStoreFilter.CLOTHES)
        {
            // Simulate Click
            OnClick();
            OnSelection();
        }
    }

    private void OnClick()
    {
        onNewCategorySelected?.Invoke(type);
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

    private void InstantiateClothes(eStoreFilter filter)
    {
        if(type == filter)
        {
            InstantiateSlots();
        }
    }

    private void InstantiateSlots()
    {
        switch (type)
        {
            case eStoreFilter.CLOTHES:
                foreach (var item in storeItems.avatarSkins.clothes.characterClothes)
                {
                    if (!item.isUnlocked)
                    {
                        GameObject obj = Instantiate(slotItemPrefab, slotParent.transform);
                        obj.GetComponent<AvatarItemSlot>().item = item;
                        obj.GetComponent<AvatarItemSlot>().isStoreSlot = true;
                        obj.GetComponent<AvatarItemSlot>().SetDesign();
                        onNewSlotItemInstantiated?.Invoke(obj);
                    }
                }
                foreach (var item in storeItems.avatarSkins.hairs.characterHairs)
                {
                    if (!item.isUnlocked)
                    {
                        GameObject obj = Instantiate(slotItemPrefab, slotParent.transform);
                        obj.GetComponent<AvatarItemSlot>().item = item;
                        obj.GetComponent<AvatarItemSlot>().isStoreSlot = true;
                        obj.GetComponent<AvatarItemSlot>().SetDesign();
                        onNewSlotItemInstantiated?.Invoke(obj);
                    }
                }
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
        StorePreview.onResetList -= InstantiateClothes;
    }

}
