using UnityEngine;

public class ControlZoom : MonoBehaviour
{
    public float zoomSpeed = 0.1f;
    public float minZoom = 1.0f;
    public float maxZoom = 2.0f;

    private RectTransform imageRectTransform;
    public RectTransform contentRectTransform;
    private float initialDistance;
    private float initialZoom;

    private void Start()
    {
        imageRectTransform = GetComponent<RectTransform>();
        contentRectTransform.sizeDelta = imageRectTransform.sizeDelta;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touch1.position, touch2.position);
                initialZoom = imageRectTransform.localScale.x;
            }

            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);
                float zoomDelta = initialDistance - currentDistance;

                float newZoom = imageRectTransform.localScale.x + zoomDelta * zoomSpeed;
                newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

                // Apply the new zoom level
                imageRectTransform.localScale = new Vector3(newZoom, newZoom, 1.0f);
                Vector2 imageSize = imageRectTransform.sizeDelta * newZoom;
                contentRectTransform.sizeDelta = imageSize;
            }
        }
        
    }
}