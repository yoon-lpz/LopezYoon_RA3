using UnityEngine;

public class StartInactive : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
