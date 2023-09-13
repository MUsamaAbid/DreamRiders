using UnityEngine;
using UnityEngine.UI;
public class ButtonDragAndDrop : MonoBehaviour
{
    private RectTransform buttonRectTransform;
    public RectTransform originalrec;
    private bool isDragging = false;
    private Vector3 offset;
    public string tagtofind;

    private void Start()
    {
        buttonRectTransform = GetComponent<RectTransform>();
        // Create a new empty GameObject
        GameObject emptyObject = new GameObject(this.gameObject.name+"ref");

        // Add a RectTransform component to the empty GameObject
        RectTransform emptyRectTransform = emptyObject.AddComponent<RectTransform>();

        // Set the parent of the RectTransform (optional)
        originalrec = emptyRectTransform;
        emptyRectTransform.SetParent(transform.parent.transform);

        // Set the position, size, and other properties of the RectTransform as needed
        //emptyRectTransform.localPosition = Vector3.zero;
        //  emptyRectTransform.sizeDelta = new Vector2(100, 100);
    }

    private void Update()
    {
        
        // Check if touch is detected
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    
                    // Check if the touch position is over the button
                    if (RectTransformUtility.RectangleContainsScreenPoint(buttonRectTransform, touch.position))
                    {

                           originalrec.sizeDelta = buttonRectTransform.sizeDelta;
                           originalrec.anchoredPosition = buttonRectTransform.anchoredPosition;
                           originalrec.anchorMin = buttonRectTransform.anchorMin;
                           originalrec.anchorMax = buttonRectTransform.anchorMax;
                           originalrec.pivot = buttonRectTransform.pivot;
                           originalrec.rotation = buttonRectTransform.rotation;
                           originalrec.localScale = buttonRectTransform.localScale;
                        // Calculate the offset between touch position and button position
                        offset = buttonRectTransform.position - new Vector3(touch.position.x, touch.position.y, buttonRectTransform.position.z);
                        isDragging = true;
                    }
                    break;
                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        // Move the button to the touch position with the offset
                        buttonRectTransform.position = new Vector3(touch.position.x, touch.position.y, buttonRectTransform.position.z) + offset;
                    }
                    break;
                case TouchPhase.Ended:
                    this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    isDragging = false;
                    break;
                case TouchPhase.Canceled:
                    this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    isDragging = false;
                    break;
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
       /* if (this.gameObject.tag == "countries")
        {
            if (other.gameObject.tag == tagtofind)
            {
                other.gameObject.GetComponent<Image>().enabled = true;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                WorldMapManager.instance.countriesfind += 1;
                Destroy(this.gameObject);
            }
            else
            {
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                buttonRectTransform.sizeDelta = originalrec.sizeDelta;
                buttonRectTransform.anchoredPosition = originalrec.anchoredPosition;
                buttonRectTransform.anchorMin = originalrec.anchorMin;
                buttonRectTransform.anchorMax = originalrec.anchorMax;
                buttonRectTransform.pivot = originalrec.pivot;
                buttonRectTransform.rotation = originalrec.rotation;
                buttonRectTransform.localScale = originalrec.localScale;
            }
        }*/
        if (this.gameObject.tag == "flags")
        {
            if (other.gameObject.tag == tagtofind)
            {
                other.gameObject.GetComponent<Image>().enabled = true;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                WorldMapManager.instance.flagsfind += 1;
                Destroy(this.gameObject);
            }
            else
            {
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                buttonRectTransform.sizeDelta = originalrec.sizeDelta;
                buttonRectTransform.anchoredPosition = originalrec.anchoredPosition;
                buttonRectTransform.anchorMin = originalrec.anchorMin;
                buttonRectTransform.anchorMax = originalrec.anchorMax;
                buttonRectTransform.pivot = originalrec.pivot;
                buttonRectTransform.rotation = originalrec.rotation;
                buttonRectTransform.localScale = originalrec.localScale;
            }
        }
    }

    
}
