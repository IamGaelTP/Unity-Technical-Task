using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Transition", menuName = "ScriptableObjects/Player/StateMachine/Create new Player Transition")]
public sealed class PlayerTransition : ScriptableObject
{
    public PlayerDecision decision;
    public PlayerBaseState TrueState;
    public PlayerBaseState FalseState;

    public void Execute(PlayerStateMachine stateMachine)
    {
        if(decision.Decide(stateMachine) && !(TrueState is RemainInState))
        {
            stateMachine.currentState.Exit(stateMachine);
            stateMachine.currentState = TrueState;
            stateMachine.currentState.Enter(stateMachine);
        }
        else if (decision.Decide(stateMachine) && !(FalseState is RemainInState))
        {
            stateMachine.currentState.Exit(stateMachine);
            stateMachine.currentState = FalseState;
            stateMachine.currentState.Enter(stateMachine);
        }
    }
}
