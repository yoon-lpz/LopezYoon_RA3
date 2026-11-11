using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance;
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}
