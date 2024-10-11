using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : AbstractInput
{
    private PlayerInputActions inputActions;

    void Start()
    {
        inputActions = new();
        inputActions.Enable();
        inputActions.Player.Move.performed += SetDirection;
    }

    private void SetDirection(InputAction.CallbackContext inputContext)
    {
        direction = inputContext.ReadValue<Vector2>();
    }
}
