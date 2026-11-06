using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour, InputSystem_Actions.IPlayerMovementActions
{
	private float _moveSpeed = 15f;
    private float _lastSpeed = 1;

	private InputSystem_Actions _inputActions;
    private Rigidbody2D _rb;
	private Vector2 _moveInput;
    private Vector3 _scale;

	[SerializeField] public bool CanChangeGravity = false;

	void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.PlayerMovement.SetCallbacks(this);
    }

    void Start() {
		_rb = GetComponent<Rigidbody2D>();
        _scale = transform.localScale;
	}

    private void OnEnable() => _inputActions.Enable();
    private void OnDisable() => _inputActions.Disable();

    void FixedUpdate() {
        _rb.linearVelocity = _moveSpeed * _moveInput;
    }

    public void OnMove(InputAction.CallbackContext context) {
        _moveInput = context.ReadValue<Vector2>();
        transform.localRotation = Quaternion.Euler(0, 180 * _moveInput.x, 0);

		/*transform.localRotation = Quaternion.Euler(0, 180 * (_moveInput.x == 0? _lastSpeed : _moveInput.x), 0);
        _lastSpeed = _moveInput.x != 0? _moveInput.x : _lastSpeed;*/
		Debug.Log(_moveInput.x);
	}
    public void OnChangeGravity(InputAction.CallbackContext context) {
        if (!CanChangeGravity) return;
        _rb.gravityScale = _rb.gravityScale * -1;
        _scale.y *= -1;
        transform.localScale = _scale;
    }
}
