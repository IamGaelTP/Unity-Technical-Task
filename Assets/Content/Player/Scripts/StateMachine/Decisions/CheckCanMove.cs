using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Check Can Move", menuName = "ScriptableObjects/Player/StateMachine/Decisions/Check Can Move")]
public class CheckCanMove : PlayerDecision
{
    public override bool Decide(PlayerStateMachine stateMachine)
    {
        return  GameManager.INSTANCE.isGamePaused || GameManager.INSTANCE.isOnTutorial ? false : true;
    }
}
