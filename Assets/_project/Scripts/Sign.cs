using System.Collections;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] private GameObject _messageUI;
    [SerializeField] private float _messageDuration = 2.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _messageUI != null)
        {
            _messageUI.SetActive(true);

            StartCoroutine(HideMessageTimer());
        }
    }

    private IEnumerator HideMessageTimer()
    {
        yield return new WaitForSeconds(_messageDuration);

        if (_messageUI != null) _messageUI.SetActive(false);
    }
}
