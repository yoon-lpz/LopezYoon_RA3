using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifeTime = 2f;

    private float lifeTimer;
    private Rigidbody2D rb;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    public void Init(Vector2 direction)
    {
        lifeTimer = lifeTime;
        rb.linearVelocity = direction.normalized * speed;
    }

    private void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0) ProjectilePool.Instance.ReturnProjectile(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (!gameObject.activeSelf) return;

        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            player.TakeDamage();
            ProjectilePool.Instance.ReturnProjectile(this);
        }

    }
}
