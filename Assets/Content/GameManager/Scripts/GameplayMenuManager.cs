using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMenuManager : MonoBehaviour
{
    private GameObject[] panels;
    public GameObject pause;
    public GameObject book;

    private void Awake()
    {
        panels = new GameObject[]
        {
            pause,
            book
        };
    }

    private void OnEnable()
    {
        BuildableItemPreview.hidePanels += HideMenus;
    }

    private void OnDisable()
    {
        BuildableItemPreview.hidePanels -= HideMenus;
    }

    private void Start()
    {
        HideMenus();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BookVisibility(true);
        }
    }

    private void HideMenus()
    {
        foreach (var item in panels)
        {
            item.SetActive(false);
        }
    }

    public void PauseVisibility(bool isActive)
    {
        HideMenus();
        pause.SetActive(isActive);
    }

    public void BookVisibility(bool isActive)
    {
        HideMenus();
        book.SetActive(isActive);
    }

}
