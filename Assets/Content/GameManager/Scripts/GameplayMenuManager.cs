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

        HideMenus();
    }

    private void OnEnable()
    {
        ExtensionMethodsMono.onHideObject += HideMenus;
        BuildableItemPreview.hidePanels += HideMenus;
    }

    private void OnDisable()
    {
        ExtensionMethodsMono.onHideObject -= HideMenus;
        BuildableItemPreview.hidePanels -= HideMenus;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(book.activeSelf)
            {
                HideMenus();
                BookVisibility(false);
            }
            else
            {
                HideMenus();
                BookVisibility(true);
            }
        }
    }

    private void HideMenus()
    {
        GameManager.INSTANCE.PauseGame(false);

        foreach (var item in panels)
        {
            item.SetActive(false);
        }
    }

    public void PauseVisibility(bool isActive)
    {
        pause.SetActive(isActive); 
        
        if (isActive)
        {
            GameManager.INSTANCE.PauseGame(true);
        }
        else
        {
            GameManager.INSTANCE.PauseGame(false);
        }
    }

    public void BookVisibility(bool isActive)
    {
        book.SetActive(isActive);

        if(isActive)
        {
            GameManager.INSTANCE.PauseGame(true);
        }
        else
        {
            GameManager.INSTANCE.PauseGame(false);
        }
    }

}
