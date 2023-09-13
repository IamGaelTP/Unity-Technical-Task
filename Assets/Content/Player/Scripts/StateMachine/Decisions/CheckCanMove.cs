using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCanMove : PlayerDecision
{
    public override bool Decide(PlayerStateMachine stateMachine)
    {
        return GameManager.INSTANCE.IS_GAME_PAUSED || GameManager.INSTANCE.IS_ON_TUTORIAL ? false : true;
    }
}
