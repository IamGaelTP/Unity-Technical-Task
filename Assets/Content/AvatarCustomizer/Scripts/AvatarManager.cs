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

    private void Start()
    {
        InstantiateSlots();
    }

    private void OnEnable()
    {
        AvatarItemPreview.onAvatarSkinBought += ResetList;
    }

    private void InstantiateSlots()
    {
        foreach (var item in avatarSkins.clothes.characterClothes)
        {
            GameObject obj = Instantiate(slotItemPrefab, slotParent.transform);
            obj.GetComponent<AvatarItemSlot>().item = item;
            obj.GetComponent<AvatarItemSlot>().SetDesign();

            if(!item.isUnlocked)
            {
                obj.GetComponent<AvatarItemSlot>().CheckSlotUnlocked();
            }

            AddToList(obj);
        }

        foreach (var item in avatarSkins.hairs.characterHairs)
        {
            GameObject obj = Instantiate(slotItemPrefab, slotParent.transform);
            obj.GetComponent<AvatarItemSlot>().item = item;
            obj.GetComponent<AvatarItemSlot>().SetDesign();

            if (!item.isUnlocked)
            {
                obj.GetComponent<AvatarItemSlot>().CheckSlotUnlocked();
            }

            AddToList(obj);
        }
    }

    private void ResetList(AvatarBaseElement elementUnlocked)
    {
        foreach (var item in itemsAvailable)
        {
            item.DestroyObject();
        }
        itemsAvailable.Clear();
        InstantiateSlots();
    }

    private void AddToList(GameObject newItem)
    {
        itemsAvailable.Add(newItem);
    }

}
