using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed = 5f;
    public float zoomSpeed = 2f;
    public float minZoomDistance = 2f;
    public float maxZoomDistance = 15f;

    public float minYAngle = -60f;
    public float maxYAngle = 60f;

    private Vector3 offset;
    private float previousMouseX;
    private float previousMouseY;
    private float currentX = 0f;
    private float currentY = 0f;
    private float currentZoomDistance = 5f;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("Camera target not assigned! Please assign a target object.");
            enabled = false;
            return;
        }

        offset = transform.position - target.position;
        Vector3 angles = transform.eulerAngles;
        currentX = angles.y;
        currentY = angles.x;
    }

    private void LateUpdate()
    {
        if (SolarSystemGameManager.Instance.takeMouseInput)
        {
            if (Input.GetMouseButtonDown(0))
            {
                float mouseX = Input.mousePosition.x;
                float mouseY = Input.mousePosition.y;

                float deltaX = mouseX - previousMouseX;
                float deltaY = mouseY - previousMouseY;
                previousMouseX = mouseX;
                previousMouseY = mouseY;

                // Rotate the camera around the target object
                // currentX += deltaX * rotateSpeed;
                //currentY -= deltaY * rotateSpeed;
                // currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);

                Vector3 angles = transform.eulerAngles;
                currentX = angles.y;
                currentY = angles.x;

                //currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
            }
            // Check for mouse input
            else if (Input.GetMouseButton(0))
            {
                float mouseX = Input.mousePosition.x;
                float mouseY = Input.mousePosition.y;

                float deltaX = mouseX - previousMouseX;
                float deltaY = mouseY - previousMouseY;
                previousMouseX = mouseX;
                previousMouseY = mouseY;

                // Rotate the camera around the target object
                currentX += deltaX * rotateSpeed;
                currentY -= deltaY * rotateSpeed;
                currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
                Debug.Log("DDDD");
            }

            // Zoom using mouse scroll
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Zoom(scroll);
        }

    }

    public void Zoom(float scroll)
    {
        currentZoomDistance -= scroll * zoomSpeed;
        currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);

        // Convert the angles to a quaternion
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // Update the camera position
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -currentZoomDistance);
        Vector3 position = rotation * negDistance + target.position;
        transform.rotation = rotation;
        transform.position = position;
    }
}
