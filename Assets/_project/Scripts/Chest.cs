using System.Collections;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject _messageUI;
    
    [SerializeField] private float _messageDuration = 2.5f;
    [SerializeField] private GameObject _plants;
    [SerializeField] private GameObject _extraMap;
    [SerializeField] private GameObject _unlockMap;

    private bool _hasTriggered = false;

    private void Awake()
    {
        if (_messageUI != null) _messageUI.SetActive(false);
        _plants.SetActive(true);
        _unlockMap.SetActive(true);
        _extraMap.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_hasTriggered && collision.CompareTag("Player") && _messageUI != null)
        {
            _hasTriggered = true;

            _plants.SetActive(false);
            _unlockMap.SetActive(false);
            _extraMap.SetActive(true);
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
