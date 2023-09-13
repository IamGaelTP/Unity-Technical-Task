using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerStateMachine), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public PlayerInputMapping input;

    public bool IS_MOVING => isMoving;
    private bool isMoving = false;

    public Vector2 MOVE_DIRECTION => moveDirection;
    private Vector2 moveDirection;

    public Vector2 POINTER_DIRECTION => pointerDirection;
    private Vector2 pointerDirection;


    private void Awake()
    {
        input = new PlayerInputMapping();
    }

    private void Start()
    {
        input.PlayerInput.Movement.performed += EnableMovement;
        input.PlayerInput.Movement.canceled += DisableMovement;

        input.PlayerInput.PointerPosition.performed += GetPointerPosition;
    }

    void OnEnable()
    {
        input.PlayerInput.Enable();
    }
    void OnDisable()
    {
        input.PlayerInput.Disable();
    }

    private void EnableMovement(InputAction.CallbackContext context)
    {
        isMoving = true;
        moveDirection = context.ReadValue<Vector2>();
    }

    private void DisableMovement(InputAction.CallbackContext context)
    {
        isMoving = false;
        moveDirection = context.ReadValue<Vector2>();
    }

    private void GetPointerPosition(InputAction.CallbackContext context)
    {
        Vector3 mousePos = context.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        pointerDirection = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnDestroy()
    {
        input.PlayerInput.Movement.performed -= EnableMovement;
        input.PlayerInput.Movement.canceled -= DisableMovement;
    }
}
