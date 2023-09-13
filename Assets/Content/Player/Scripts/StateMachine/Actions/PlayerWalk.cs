using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Walk Action", menuName = "ScriptableObjects/Player/StateMachine/Actions/Walk")]
public class PlayerWalk : PlayerAction
{
    [SerializeField] private float speed = 50.0f;

    public override void Enter(PlayerStateMachine stateMachine)
    {
        
    }

    public override void Execute(PlayerStateMachine stateMachine)
    {
        Rigidbody2D rb = stateMachine.GetComponent<Rigidbody2D>();
        Vector2 direction = stateMachine.GetComponent<PlayerController>().MOVE_DIRECTION;
        if (direction.magnitude > 0)
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    public override void Exit(PlayerStateMachine stateMachine)
    {

    }
}
