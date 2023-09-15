using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player State", menuName = "ScriptableObjects/Player/StateMachine/Create new Player State")]
public class PlayerState : PlayerBaseState
{
    public List<PlayerAction> actions = new List<PlayerAction>();
    public List<PlayerTransition> transitions = new List<PlayerTransition>();

    public override void Enter(PlayerStateMachine stateMachine)
    {
        foreach (var action in actions)
        {
            action.Enter(stateMachine);
        }
    }

    public override void Execute(PlayerStateMachine stateMachine)
    {
        foreach (var action in actions)
        {
            action.Execute(stateMachine);
        }

        foreach (var transition in transitions)
        {
            transition.Execute(stateMachine);
        }
    }

    public override void Exit(PlayerStateMachine stateMachine)
    {
        foreach (var action in actions)
        {
            action.Enter(stateMachine);
        }
    }
}
