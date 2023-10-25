using UnityEngine;

public class PinchToZoom : MonoBehaviour
{
    public float zoomSpeed = 0.1f;
    public float minZoom = 1.0f;
    public float maxZoom = 5.0f;

    private float initialPinchDistance;
    private float initialZoom;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            float currentPinchDistance = Vector2.Distance(touch0.position, touch1.position);

            if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
            {
                initialPinchDistance = currentPinchDistance;
                initialZoom = Camera.main.fieldOfView;
            }
            else if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
            {
                float pinchDifference = currentPinchDistance - initialPinchDistance;
                float zoomAmount = pinchDifference * zoomSpeed;
                float newZoom = initialZoom - zoomAmount;

                newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

                Camera.main.fieldOfView = newZoom;
            }
        }
    }
}
