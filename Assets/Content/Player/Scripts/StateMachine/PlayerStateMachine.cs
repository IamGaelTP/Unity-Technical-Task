using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private PlayerBaseState initialState;
    public PlayerBaseState currentState { get; set; }
    public PlayerBaseState previewCurrentState;

    private void Awake()
    {
        currentState = initialState;
        previewCurrentState = currentState;
    }

    private void Start()
    {
        currentState.Enter(this);
    }

    private void FixedUpdate()
    {
        currentState.Execute(this);
    }

    public void ResetState()
    {
        currentState = initialState;
        previewCurrentState = currentState;
        currentState.Enter(this);
    }

}
