using UnityEngine;

public class SpriteZoom : MonoBehaviour
{
    public float zoomSpeed = 1.0f;
    public float minZoom = 1.0f;
    public float maxZoom = 5.0f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize - zoomAmount, minZoom, maxZoom);
    }
}
