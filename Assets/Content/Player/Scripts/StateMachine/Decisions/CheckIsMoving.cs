using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Check Is Moving", menuName = "ScriptableObjects/Player/StateMachine/Decisions/Check Is Moving")]
public class CheckIsMoving : PlayerDecision
{
    public PlayerDecision canMove;

    public override bool Decide(PlayerStateMachine stateMachine)
    {
        if(canMove.Decide(stateMachine))
        {
            return stateMachine.GetComponent<PlayerController>().isMoving ? true : false;
        }
        else
        {
            return false;
        }
    }
}