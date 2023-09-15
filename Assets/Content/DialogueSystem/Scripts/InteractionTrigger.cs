using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractionTrigger : MonoBehaviour
{
    private bool isOnTrigger = false;
    public static event Action onSpeakerInteraction;
    [SerializeField] private GameObject keyAlert;


    private void OnEnable()
    {
        PlayerController.onInteraction += Speak;  
    }

    private void OnDisable()
    {
        PlayerController.onInteraction -= Speak;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isOnTrigger = true;
            keyAlert.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnTrigger = false;
            keyAlert.SetActive(false);
        }
    }

    private void Speak(bool isOnInteraction)
    {
        if(isOnTrigger && isOnInteraction)
        {
            onSpeakerInteraction?.Invoke();
        }
    }

}
