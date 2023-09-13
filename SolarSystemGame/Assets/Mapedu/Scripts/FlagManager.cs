using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagManager : MonoBehaviour
{
    public static FlagManager Instance;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject FlagsFolder;
    [SerializeField] GameObject FlagPrefab;
    public Transform FlagParentTransfrom;
    public List<Sprite> FlagsList = new List<Sprite>();
    public bool isDragging = false;
    int totalFlags;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        totalFlags = FlagsFolder.transform.childCount;
        
    }

    public void SetUpFlagsforCurrentLevl(int NumberOfFlags)
    {
        for (int i = PrefsHandler.instance.GetGameLevel()*10 ; i < NumberOfFlags; i++)
        {
            Sprite FlagSprite = FlagsFolder.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
            GameObject Flag = Instantiate(FlagPrefab, FlagParentTransfrom);
            //Flag.name = FlagSprite.name;
            Flag.GetComponent<Drag>().canvas = canvas;
            Flag.GetComponent<Drag>().content = FlagParentTransfrom.gameObject;
            Flag.GetComponent<Image>().sprite = FlagSprite;
            FlagsList.Add(FlagSprite);
        }
    }
}
