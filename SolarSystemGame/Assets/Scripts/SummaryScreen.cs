using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryScreen : MonoBehaviour
{
    public static SummaryScreen instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject SummaryMenu;

    [SerializeField] GameObject Star1;
    [SerializeField] GameObject Star2;
    [SerializeField] GameObject Star3;

    [SerializeField] Text scoreText;
    [SerializeField] Text timeText;

    float timePassed;

    public void SetTimePassed(float timePass)
    {
        timePassed = timePass;
    }

    public void UpdateTimeText(string t)
    {
        timeText.text = t;
    }
    public void StartGameEndSequence()
    {
        UpdateScore();
        SummaryMenu.SetActive(true);
    }

    private void UpdateScore()
    {
        if (timePassed < 150 && timePassed > 120)
        {
            Debug.Log("Full stars");
            scoreText.text = "300";

            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
        }
        else if (timePassed < 120 && timePassed > 60)
        {
            Debug.Log("Two stars");
            scoreText.text = "200";

            Star1.SetActive(true);
            Star2.SetActive(true);
        }
        else if (timePassed < 60 || timePassed > 149)
        {
            Debug.Log("One stars");
            scoreText.text = "100";

            Star1.SetActive(true);
        }
    }
}
