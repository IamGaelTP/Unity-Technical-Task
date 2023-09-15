using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : ScriptableObject
{
    public virtual void Enter(PlayerStateMachine stateMachine) { }
    public virtual void Execute(PlayerStateMachine stateMachine) { }
    public virtual void Exit(PlayerStateMachine stateMachine) { }
}
