using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum eMouseButton
{
    LEFT,
    RIGHT
}

[RequireComponent(typeof(PlayerStateMachine), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public PlayerInputMapping input;

    public bool isMoving { get; private set; }

    public Vector2 moveDirection { get; private set; }

    public Vector2 pointerDirection { get; private set; }

    public bool isLeftMouseButtonPressed { get; private set; }
    public bool isRightMouseButtonPressed { get; private set; }


    private void Awake()
    {
        input = new PlayerInputMapping();
    }

    void OnEnable()
    {
        input.PlayerInput.Enable(); input.PlayerInput.Movement.performed += EnableMovement;
        input.PlayerInput.Movement.canceled += DisableMovement;

        input.PlayerInput.PointerPosition.performed += GetPointerPosition;
        input.PlayerInput.PerformAction.performed += OnPerformActionPerformed;
        input.PlayerInput.PerformAction.canceled += OnPerformActionCancelled;
        input.PlayerInput.CancelAction.performed += OnCancelActionPerformed;
        input.PlayerInput.CancelAction.canceled += OnCancelActionCancelled;
    }
    void OnDisable()
    {
        input.PlayerInput.Movement.performed -= EnableMovement;
        input.PlayerInput.Movement.canceled -= DisableMovement;
        input.PlayerInput.PointerPosition.performed -= GetPointerPosition;
        input.PlayerInput.PerformAction.performed -= OnPerformActionPerformed;
        input.PlayerInput.PerformAction.canceled -= OnPerformActionCancelled;
        input.PlayerInput.CancelAction.performed -= OnCancelActionPerformed;
        input.PlayerInput.CancelAction.canceled -= OnCancelActionCancelled;
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

    private void OnPerformActionPerformed(InputAction.CallbackContext context)
    {
        isLeftMouseButtonPressed = true;
    }
    private void OnCancelActionPerformed(InputAction.CallbackContext context)
    {
        isRightMouseButtonPressed = true;
    }
    private void OnPerformActionCancelled(InputAction.CallbackContext context)
    {
        isLeftMouseButtonPressed = false;
    }
    private void OnCancelActionCancelled(InputAction.CallbackContext context)
    {
        isRightMouseButtonPressed = false;
    }

    public bool IsMouseButtonPressed(eMouseButton button)
    {
        return button == eMouseButton.LEFT ? isLeftMouseButtonPressed : isRightMouseButtonPressed;
    }
}
