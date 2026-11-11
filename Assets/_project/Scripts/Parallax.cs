using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier = 0.4f;
    [SerializeField] private Transform player;
    private float lastPlayerX;

    void Start()
    {
        if (player != null)
        {
            lastPlayerX = player.position.x;
        }
    }

    void Update()
    {
        if (player == null) return;

        float deltaX = player.position.x - lastPlayerX;
        transform.position += new Vector3(deltaX * parallaxMultiplier, 0, 0);
        lastPlayerX = player.position.x;
    }
}