using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryInfo : MonoBehaviour
{
    //private void OnMouseUp()
    //{
    //    Debug.Log("vchgdvchdb");
    //}
    //private void OnMouseDown()
    //{
    //    Debug.Log("vghyghjgj");
    //}
    private void OnMouseEnter()
    {
        if(FlagManager.Instance.isDragging)
            MapManager.Instance.CurrentCountryPosition = transform.position;
        //Debug.Log("position " + MapManager.Instance.CurrentCountryPosition);
    }

    
}