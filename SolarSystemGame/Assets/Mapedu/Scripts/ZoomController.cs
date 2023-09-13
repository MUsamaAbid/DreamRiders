using UnityEngine;
using UnityEngine.UI;

public class ZoomController : MonoBehaviour
{

    [SerializeField] Slider ZoomSlider;
    [SerializeField] Camera cam;

    [SerializeField] SpriteRenderer mapRenderer;

    [SerializeField] private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    [SerializeField] bool OnSlider = false;
    private void Awake()
    {
        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if (cam.orthographicSize < 454 && !OnSlider && !FlagManager.Instance.isDragging)
            PanCamera();

    }

    public void CameraZoom()
    {
        float v = ZoomSlider.value - ZoomSlider.minValue;
        v = ZoomSlider.maxValue - v;
        cam.orthographicSize = v;
        cam.transform.position = ClampCamera(cam.transform.position);
        //cam.transform.position = ClampCamera(cam.transform.position);
    }


    Vector3 dragOrgin;
    public void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(Input.mousePosition);
            dragOrgin = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 difference = dragOrgin - Input.mousePosition;
            //Debug.Log("orgin " + dragOrgin + " newPosition " + Input.mousePosition + " = " + difference);
            
            cam.transform.position = ClampCamera(cam.transform.position + difference * 0.1f);
            //cam.transform.position += difference * 0.01f;
        }
    }

    public Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }

    public void OnSliderHoverEnter()
    {
        OnSlider = true;
    }

    public void OnSliderHoverExit()
    {
        OnSlider = false;
      
    }
}