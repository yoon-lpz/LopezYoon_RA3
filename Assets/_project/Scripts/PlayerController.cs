using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour, InputSystem_Actions.IPlayerMovementActions
{
    private float _moveSpeed = 15f, _targetAngle;

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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Deathtouch")) Die();
    }

    public void OnMove(InputAction.CallbackContext context) {
        _moveInput = context.ReadValue<Vector2>();

        if (_moveInput.x != 0)
        {
            _targetAngle = _moveInput.x > 0 ? 0 : 180f;
            transform.localRotation = Quaternion.Euler(0, _targetAngle, 0);
        }
	}
    public void OnChangeGravity(InputAction.CallbackContext context) {
        if (!CanChangeGravity) return;
        _rb.gravityScale = _rb.gravityScale * -1;
        _scale.y *= -1;
        transform.localScale = _scale;
    }

    public void Die() {
        
    }
}
