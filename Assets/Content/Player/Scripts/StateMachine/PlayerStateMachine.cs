using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private PlayerBaseState initialState;
    public PlayerBaseState currentState { get; set; }

    private void Awake()
    {
        currentState = initialState;
    }

    private void Start()
    {
        currentState.Enter(this);
    }

    private void Update()
    {
        currentState.Execute(this);
    }

    public void ResetState()
    {
        currentState = initialState; 
        currentState.Enter(this);
    }

}
