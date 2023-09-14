using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneManagerTrigger : MonoBehaviour
{
    [SerializeField] private eGameStates newGameState;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.INSTANCE.SetNewGameState(newGameState);
        }
    }

    public void LoadNewScene()
    {
        GameManager.INSTANCE.SetNewGameState(newGameState);
        Debug.Log($"New Scene Called> {Enum.GetName(typeof(eGameStates), newGameState)}");
    }
}
