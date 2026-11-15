using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool Instance;

    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private int _initialSize = 20;

    private Stack<Projectile> pool = new Stack<Projectile>();

    private void Awake()
    {

        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        for (int i = 0; i < _initialSize; i++) pool.Push(CreateProjectile());
    }

    private Projectile CreateProjectile()
    {
        Projectile projectile = Instantiate(_projectilePrefab, transform);
        projectile.gameObject.SetActive(false);
        return projectile;
    }

    public Projectile GetProjectile(Vector3 position, Quaternion rotation, Vector2 direction)
    {
        Projectile projectile;
        projectile = pool.Count > 0 ? pool.Pop() : CreateProjectile();

        projectile.transform.SetPositionAndRotation(position, rotation);
        projectile.gameObject.SetActive(true);

        projectile.Init(direction);
        return projectile;
    }

    public void ReturnProjectile(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        pool.Push(projectile);
    }
}
