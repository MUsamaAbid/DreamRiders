using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    [SerializeField] GameObject WorldMap;
    [SerializeField] List<GameObject> WorldCountries = new List<GameObject>();
    [SerializeField] int totalCountries=0;
    [SerializeField] GameObject _FlagPlacement;

    public Vector3 CurrentCountryPosition;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        totalCountries = WorldMap.transform.childCount;
        for (int i= 0; i< totalCountries; i++)
        {

            GameObject country =  WorldMap.transform.GetChild(i).gameObject;
            GameObject Flag = Instantiate(_FlagPlacement, country.transform);

            SpriteRenderer countrySR = country.GetComponent<SpriteRenderer>();
            SpriteRenderer FlagSR = Flag.GetComponent<SpriteRenderer>();
            country.GetComponent<SpriteMask>().sprite = countrySR.sprite;
            
            FlagSR.sortingOrder = countrySR.sortingOrder + 1;
            WorldCountries.Add(country);
        }
    }

    public void OnHoverEnter()
    {
        Debug.Log("It on Australia");
    }

    public void OnHoverExit()
    {
        Debug.Log("no longer on Australia");
    }

}
