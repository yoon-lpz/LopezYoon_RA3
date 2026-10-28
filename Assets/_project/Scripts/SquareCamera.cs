using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SquareCamera : MonoBehaviour
{
    void Start() {
        Camera cam = GetComponent<Camera>();
        float scaleHeight = ((float)Screen.width / Screen.height) * 1.0f;
		cam.rect = new Rect(0.25f, 0.0f, 0.5f, 1.0f);
	}
}
