using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AvatarCustomizer : MonoBehaviour
{
    [field: SerializeField] public AvatarSkin defaultSkin { get; private set; }
    [field: SerializeField] public GameObject basePlayer { get; private set; }
    
    private AvatarSkin currentSkin;
    private AvatarSkin lastSkin;

    public static event Action<AvatarSkin> onAvatarUpdated;

    private GameObject currentBase, currentHair, currentClothes;


    private void Awake()
    {
        currentSkin = Instantiate(defaultSkin);
        lastSkin = currentSkin;
    }

    private void Start()
    {
        InitBlackSmith();
    }

    private void InitBlackSmith()
    {
        InstantiateSkin(defaultSkin.baseBody, eAvatarElement.BASE, false);
        InstantiateSkin(defaultSkin.hair, eAvatarElement.HAIR, false);
        InstantiateSkin(defaultSkin.clothes, eAvatarElement.CLOTHES, false);
        ConfirmSave();
    }

    private void OnEnable()
    {
        AvatarItemSlot.onAvatarSlotSelected += InstantiateSkin;
    }

    private void OnDisable()
    {
        AvatarItemSlot.onAvatarSlotSelected -= InstantiateSkin;
    }

    private void InstantiateSkin(AvatarBaseElement item, eAvatarElement type, bool isStoreSlot)
    {
        if(!isStoreSlot)
        {
            GameObject obj = Instantiate(item.prefab, basePlayer.transform);
            SaveSkin(obj, item, type);
        }
    }

    private void SaveSkin(GameObject obj, AvatarBaseElement item, eAvatarElement type)
    {
        switch (type)
        {
            case eAvatarElement.BASE:
                if (currentBase != null) currentBase.DestroyObject();
                currentSkin.NewBody(item);
                currentBase = obj;
                break;
            case eAvatarElement.HAIR:
                if (currentHair != null) currentHair.DestroyObject();
                currentSkin.NewHair(item);
                currentHair = obj;
                break;
            case eAvatarElement.CLOTHES:
                if (currentClothes != null) currentClothes.DestroyObject();
                currentSkin.NewClothes(item);
                currentClothes = obj;
                break;
            default:
                break;
        }

        onAvatarUpdated?.Invoke(currentSkin);
    }

    private void ConfirmSave()
    {
        lastSkin = currentSkin;
    }

    private void CancelSkin()
    {
        currentSkin = lastSkin;
    }

}
