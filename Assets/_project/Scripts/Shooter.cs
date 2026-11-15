using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 1.5f;
    private float _nextFireTime;
    public bool isInverted = false;

    private void Update()
    {
        if (Time.time >= _nextFireTime)
        {
            Shoot();
            _nextFireTime = Time.time + _fireRate;
        }
    }

    public void Shoot()
    {
        if (_firePoint != null && ProjectilePool.Instance != null)
        {
            Vector2 shootDirection = isInverted ? Vector2.right : Vector2.left;
            ProjectilePool.Instance.GetProjectile(_firePoint.position, _firePoint.rotation, shootDirection);
        }
    }
}
