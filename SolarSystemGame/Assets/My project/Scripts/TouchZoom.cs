using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class TouchZoom : MonoBehaviour
{
    public float zoomSpeed = 0.5f; // Adjust the zoom speed as needed
    public float minZoomDistance = 1.0f; // Minimum distance the camera can be from the target
    public float maxZoomDistance = 10.0f; // Maximum distance the camera can be from the target

    private Camera mainCamera;
    private Vector2 initialTouch1Pos;
    private Vector2 initialTouch2Pos;
    private float initialZoomDistance;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                initialTouch1Pos = touch1.position;
                initialTouch2Pos = touch2.position;
                initialZoomDistance = Vector2.Distance(initialTouch1Pos, initialTouch2Pos);
            }
            else if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
            {
                Vector2 touch1Pos = touch1.position;
                Vector2 touch2Pos = touch2.position;

                float currentZoomDistance = Vector2.Distance(touch1Pos, touch2Pos);
                float zoomAmount = (currentZoomDistance - initialZoomDistance) * zoomSpeed;

                // Calculate the new camera distance
                float newDistance = mainCamera.transform.localPosition.z - zoomAmount;
                newDistance = Mathf.Clamp(newDistance, -maxZoomDistance, -minZoomDistance);

                // Apply the new camera position
                Vector3 newPosition = mainCamera.transform.localPosition;
                newPosition.z = newDistance;
                mainCamera.transform.localPosition = newPosition;
            }
        }
    }
}
