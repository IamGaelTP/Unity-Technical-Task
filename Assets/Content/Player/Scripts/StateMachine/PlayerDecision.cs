using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerDecision : ScriptableObject
{
    public abstract bool Decide(PlayerStateMachine stateMachine);
}
