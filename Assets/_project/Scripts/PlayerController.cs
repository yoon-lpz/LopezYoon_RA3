using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, InputSystem_Actions.IPlayerMovementActions
{
	private float _moveSpeed = 15f;
	private InputSystem_Actions _inputActions;
    private Vector2 _moveInput;
    private Rigidbody2D rb;

    void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.PlayerMovement.SetCallbacks(this);
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() => _inputActions.Enable();
    private void OnDisable() => _inputActions.Disable();

    void FixedUpdate() {
        rb.linearVelocity = _moveSpeed * _moveInput;
    }

    public void OnMove(InputAction.CallbackContext context) {
        _moveInput = context.ReadValue<Vector2>();

	}
}
