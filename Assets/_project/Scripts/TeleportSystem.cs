using UnityEngine;

public class TeleportSystem : MonoBehaviour
{
    [SerializeField] private Transform _destination;

    private void OnTriggerEnter2D(Collider collision)
    {
        if (collision.CompareTag("Player") && _destination != null)
        {
            collision.transform.position = _destination.position;
        }
    }
}
