using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AvatarManager : MonoBehaviour
{
    [Header("Database")]
    public AvatarSkinsDatabase avatarSkins;

    [Header("Item")]
    public GameObject slotItemPrefab;
    public GameObject slotParent;

    private List<GameObject> itemsAvailable = new List<GameObject>();

    private void OnEnable()
    {
        ItemSlot.onSlotSelected += ResetSlotsDesign;
        AvatarItemPreview.onAvatarSkinBought += ResetList;
        InstantiateSlots();
    }

    private void OnDisable()
    {
        ItemSlot.onSlotSelected -= ResetSlotsDesign;
        AvatarItemPreview.onAvatarSkinBought -= ResetList;
        ResetList(null);
    }

    private void InstantiateSlots()
    {
        foreach (var item in avatarSkins.clothes.characterClothes)
        {
            GameObject obj = Instantiate(slotItemPrefab, slotParent.transform);
            obj.GetComponent<AvatarItemSlot>().item = item;
            obj.GetComponent<AvatarItemSlot>().isStoreSlot = false;
            obj.GetComponent<AvatarItemSlot>().type = eAvatarElement.CLOTHES;
            obj.GetComponent<AvatarItemSlot>().SetDesign();

            AddToList(obj);
        }

        foreach (var item in avatarSkins.hairs.characterHairs)
        {
            GameObject obj = Instantiate(slotItemPrefab, slotParent.transform);
            obj.GetComponent<AvatarItemSlot>().item = item;
            obj.GetComponent<AvatarItemSlot>().isStoreSlot = false;
            obj.GetComponent<AvatarItemSlot>().type = eAvatarElement.HAIR;
            obj.GetComponent<AvatarItemSlot>().SetDesign();

            AddToList(obj);
        }
    }

    private void ResetSlotsDesign()
    {
        foreach (var item in itemsAvailable)
        {
            item.GetComponent<AvatarItemSlot>().ResetToNormalDesign();
        }
    }

    private void ResetList(AvatarBaseElement elementUnlocked)
    {
        foreach (var item in itemsAvailable)
        {
            item.DestroyObject();
        }
        itemsAvailable.Clear();

        if(elementUnlocked != null)
        {
            InstantiateSlots();
        }
    }

    private void AddToList(GameObject newItem)
    {
        itemsAvailable.Add(newItem);
    }

}
