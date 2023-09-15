using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CinematicTrigger : MonoBehaviour
{
    public static event Action<string> onCinematicIsTriggered;
    [field: SerializeField] public string transitionName { get; private set; } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            onCinematicIsTriggered?.Invoke(transitionName);
        }
    }

}
