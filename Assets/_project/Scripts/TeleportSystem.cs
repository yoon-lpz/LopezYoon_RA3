using System.Collections;
using UnityEngine;

public class TeleportSystem : MonoBehaviour
{
    [SerializeField] private Transform _destination;
    private bool _canTeleport = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_canTeleport && collision.CompareTag("Player") && _destination != null)
        {
            collision.transform.position = _destination.position;

            TeleportSystem destinationTeleporter = _destination.GetComponent<TeleportSystem>();
            if (destinationTeleporter != null)
            {
                destinationTeleporter.StartCoroutine(destinationTeleporter.Cooldown());
            }
        }
    }

    public IEnumerator Cooldown()
    {
        _canTeleport = false;
        yield return new WaitForSeconds(0.5f);
        _canTeleport = true;
    }
}
