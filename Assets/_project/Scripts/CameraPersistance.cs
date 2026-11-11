using UnityEngine;

public class CameraPersistance : MonoBehaviour
{
    public static CameraPersistance Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
}
