using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Canvas canvas;
    public GameObject content;
    bool dragend = false;
    Vector3 orgin = Vector3.zero;
    Vector3 orgin2 = Vector3.zero;
    private void Update()
    {
        if(dragend)
        {
            Debug.DrawRay(orgin2, transform.forward *10000 , Color.blue);
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //if(touch.phase == TouchPhase.Began)
        }
    }


    //public void DragHandler(BaseEventData data)
    //{
    //    FlagManager.Instance.isDragging = true;
    //    this.transform.SetParent(canvas.transform);
    //    PointerEventData pointerData = (PointerEventData)data;

    //    Vector2 position;

    //    RectTransformUtility.ScreenPointToLocalPointInRectangle(
    //        (RectTransform)canvas.transform,
    //        pointerData.position,
    //        canvas.worldCamera,
    //        out position);

    //    transform.position = canvas.transform.TransformPoint(position);
    //}

    
    //public void DragEndHandler( BaseEventData data)
    //{
    //    dragend = true;
    //    FlagManager.Instance.isDragging = false;
       
    //    PointerEventData pointerData = (PointerEventData)data;
    //    orgin = Camera.main.ScreenToWorldPoint(new Vector3 (pointerData.position.x, pointerData.position.y,750));
    //    pointer = pointerData.position;
    //    //Debug.Log("orgin: " + orgin);
    //    orgin2 = Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, transform.position.y, 750));
    //    Debug.DrawLine(transform.position, MapManager.Instance.CurrentCountryPosition,Color.red);
        
    //    RaycastHit2D hitInfo = Physics2D.Raycast(orgin2, transform.forward * 10000);
    //    if(hitInfo)
    //    {
    //        if (hitInfo.collider.tag == "countries")
    //        {
    //            string name = gameObject.GetComponent<Image>().sprite.name;
    //            // assign the sprite of flag to country if flag name and country name matches 
    //            if (name.ToLower().Contains(hitInfo.collider.name.ToLower()))
    //            {
    //                SoundEffects.Instance.CorrectSelectionSound();
    //                hitInfo.collider.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = this.gameObject.GetComponent<Image>().sprite;
    //                Debug.Log("flag and country match");
    //                GameManager.Instance.UpdateScore();
    //                Destroy(gameObject);
    //            }
    //            else
    //            {
    //                Debug.Log("play SFX");
    //                SoundEffects.Instance.IncorrectSelectionSound();
    //                this.transform.SetParent(content.transform);
    //            }
    //            Debug.Log("HIIIITTT");
                

    //        }
    //        else
    //        {
    //            Debug.Log("play SFX");
    //            SoundEffects.Instance.IncorrectSelectionSound();
    //            this.transform.SetParent(content.transform);
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("play SFX");
    //        SoundEffects.Instance.IncorrectSelectionSound();
    //        this.transform.SetParent(content.transform);
    //    }
       
    //}

    //public void DragStart(BaseEventData data)
    //{
    //   Camera.main.transform.position = GameManager.Instance.ZoomManager.ClampCamera(Camera.main.transform.position);
    //}

    public void OnBeginDrag(PointerEventData eventData)
    {
        Camera.main.transform.position = GameManager.Instance.ZoomManager.ClampCamera(Camera.main.transform.position);
    }

    public void OnDrag(PointerEventData eventData)
    {

        FlagManager.Instance.isDragging = true;
        this.transform.SetParent(canvas.transform);
        //PointerEventData pointerData = (PointerEventData)eventData;

        //Vector2 position;

        //RectTransformUtility.ScreenPointToLocalPointInRectangle(
        //    (RectTransform)canvas.transform,
        //    eventData.position,
        //    Camera.main,
        //    out position);

        transform.position = eventData.position;//canvas.transform.TransformPoint(position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragend = true;
        FlagManager.Instance.isDragging = false;

        PointerEventData pointerData = eventData;
        orgin = Camera.main.ScreenToWorldPoint(new Vector3(pointerData.position.x, pointerData.position.y, 750));
       
        //Debug.Log("orgin: " + orgin);
        orgin2 = Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, transform.position.y, 750));
        Debug.DrawLine(transform.position, MapManager.Instance.CurrentCountryPosition, Color.red);

        RaycastHit2D hitInfo = Physics2D.Raycast(orgin2, transform.forward * 10000);
        if (hitInfo)
        {
            if (hitInfo.collider.tag == "countries")
            {
                string name = gameObject.GetComponent<Image>().sprite.name;
                // assign the sprite of flag to country if flag name and country name matches 
                if (name.ToLower().Contains(hitInfo.collider.name.ToLower()))
                {
                    SoundEffects.Instance.CorrectSelectionSound();
                    hitInfo.collider.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = this.gameObject.GetComponent<Image>().sprite;
                    Debug.Log("flag and country match");
                    GameManager.Instance.UpdateScore();
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("play SFX");
                    SoundEffects.Instance.IncorrectSelectionSound();
                    this.transform.SetParent(content.transform);
                }
                Debug.Log("HIIIITTT");


            }
            else
            {
                Debug.Log("play SFX");
                SoundEffects.Instance.IncorrectSelectionSound();
                this.transform.SetParent(content.transform);
            }
        }
        else
        {
            Debug.Log("play SFX");
            SoundEffects.Instance.IncorrectSelectionSound();
            this.transform.SetParent(content.transform);
        }
    }
}
