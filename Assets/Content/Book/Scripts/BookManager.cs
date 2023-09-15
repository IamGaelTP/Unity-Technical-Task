using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ePages
{
    INVENTORY,
    STORE,
    AVATAR
}

public enum eStoreFilter
{
    CLOTHES,
    BUILDINGS
}

public class BookManager : MonoBehaviour
{
    public GameObject[] pages;
    public ePages currentPage { get; private set; }

    private void OnEnable()
    {
        BookPageBtn.onBookPageSelected += SetNewPage;
    }

    private void OnDisable()
    {
        BookPageBtn.onBookPageSelected -= SetNewPage;
    }

    private void Start()
    {
        foreach (var page in pages)
        {
            page.SetActive(false);
        }
        pages[0].SetActive(true);
    }

    private void SetNewPage(ePages newPage)
    {
        currentPage = newPage;
        switch (currentPage)
        {
            case ePages.INVENTORY:
                ShowPage(1);
                break;
            case ePages.STORE:
                ShowPage(2);
                break;
            case ePages.AVATAR:
                ShowPage(0);
                break;
            default:
                break;
        }
    }

    private void ShowPage(int index)
    {
        foreach (var page in pages)
        {
            page.SetActive(false);
        }
        pages[index].SetActive(true);
    }

}
