using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SumerPanelReferences : MonoBehaviour
{
    public GameObject WinPanel;
    public GameObject LosePanel;
    public TMP_Text DreamCoins;
    public GameObject Stars;

    public GameObject NextButton;
    public GameObject RetryButton;


    public void UpdateStarEarned(int totalStars)
    {
        switch (totalStars)
        {
            case 0:
                Debug.Log("No Stars");
                break;
            case 1:
                Stars.transform.GetChild(0).gameObject.SetActive(true);
                Debug.Log("One Stars");
                break;
            case 2:
                Stars.transform.GetChild(0).gameObject.SetActive(true);
                Stars.transform.GetChild(1).gameObject.SetActive(true);
                Debug.Log("Two Stars");
                break;
            case 3:
                Stars.transform.GetChild(0).gameObject.SetActive(true);
                Stars.transform.GetChild(1).gameObject.SetActive(true);
                Stars.transform.GetChild(2).gameObject.SetActive(true);
                Debug.Log("Three Stars");
                break;
        }
    }
}
