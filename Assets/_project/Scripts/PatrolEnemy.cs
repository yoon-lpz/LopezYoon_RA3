using UnityEditor.Tilemaps;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed = 2f;

    [Header("Patrol sensors")]
    [SerializeField] private Transform _edgeCheck;
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _checkDistance = 0.5f;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rb;

    private void Awake() => _rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
        _rb.linearVelocity = new Vector2(transform.right.x * _speed, _rb.linearVelocity.y);
        RaycastHit2D groundInfo = Physics2D.Raycast(_edgeCheck.position, Vector2.down, _checkDistance, _groundLayer);
        RaycastHit2D wallInfo = Physics2D.Raycast(_wallCheck.position, transform.right, _checkDistance, _groundLayer);

        Debug.DrawRay(_edgeCheck.position, Vector3.down * _checkDistance, Color.red);
        Debug.DrawRay(_wallCheck.position, transform.right * _checkDistance, Color.blue);

        if (groundInfo.collider == null || wallInfo.collider != null) Flip();
    }

    private void Flip() => transform.Rotate(0f, 180f, 0f);
}
