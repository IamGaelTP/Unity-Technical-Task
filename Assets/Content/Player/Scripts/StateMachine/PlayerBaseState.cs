using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : ScriptableObject
{
    public virtual void Enter(PlayerStateMachine stateMachine) { }
    public virtual void Execute(PlayerStateMachine stateMachine) { }
    public virtual void Exit(PlayerStateMachine stateMachine) { }
}
