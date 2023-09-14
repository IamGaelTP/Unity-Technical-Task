using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ePages
{
    INVENTORY,
    STORE
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

    private void SetNewPage(ePages newPage)
    {
        currentPage = newPage;
        switch (currentPage)
        {
            case ePages.INVENTORY:
                ShowPage(0);
                break;
            case ePages.STORE:
                ShowPage(1);
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
