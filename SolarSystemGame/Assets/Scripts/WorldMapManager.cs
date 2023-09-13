using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WorldMapManager : MonoBehaviour
{
  //  public string[] countries;
  //  public string[] countriescities;
  //  public Sprite[] flags;
    // Declare the list to hold integers
 //   List<string> CountryNameList = new List<string>();
  //  List<Sprite> CountryFlagList = new List<Sprite>();
 //   List<string> CountryCitiesNameList = new List<string>();
  //  public int countriesfind;
 //   private bool countriestofind;
    public int flagsfind;
    private bool flagstofind;
    public GameObject instructionpanel;
    public Text whattodo;
   // public GameObject firstCountries;
    public GameObject secondflags;
    public string[] countriesname;
    public Sprite[] flags;
    public int targetflags;
    public GameObject flagbutton;
    public GameObject buttonsparent;
    public static WorldMapManager instance;
    void Start()
    {
        instance = this;
     //   countriesfind = 0;
    //    countriestofind = false;
        flagsfind = 0;
        flagstofind = false;
     //   CountryNameList.AddRange(countries);
     //   CountryFlagList.AddRange(flags);
    //    CountryCitiesNameList.AddRange(countriescities);
      //  firstCountries.SetActive(true);
      for(int i=0;i< targetflags;i++)
        {
            GameObject coun = Instantiate(flagbutton);
            coun.transform.SetParent(buttonsparent.transform);
            coun.GetComponent<Image>().sprite = flags[i];
            coun.gameObject.name = countriesname[i];
            coun.GetComponent<ButtonDragAndDrop>().tagtofind = countriesname[i];
        }
        instructionpanel.SetActive(true);
        whattodo.text = "you have to place all the flags. Let do that";
        Invoke("disableinstruction", 3.0f);
    }
    public void disableinstruction()
    {
        instructionpanel.SetActive(false);
    }
    public void Update()
    {
      /*  if (countriesfind >= 6 && countriestofind ==  false)
        {
            countriestofind = true;
            instructionpanel.SetActive(true);
            whattodo.text = "you have find all the countries. Let move to next part. now you have to drag all flags to corresponding countries";
            Invoke("disableinstructionforsecond", 3.0f);
        }*/
        if (flagsfind >= 6 && flagstofind == false)
        {
            flagstofind = true;
            instructionpanel.SetActive(true);
            whattodo.text = "you have find all the flags.";
        }
    }
   /* public void disableinstructionforsecond()
    {
        instructionpanel.SetActive(false);
        firstCountries.SetActive(false);
        secondflags.SetActive(true);
    }*/
}
