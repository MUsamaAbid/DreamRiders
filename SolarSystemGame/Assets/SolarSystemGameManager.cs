using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[Serializable]
public class Question
{
    public string QuestionText;
    public int RightOption;
}


public class SolarSystemGameManager : MonoBehaviour
{
    public GameObject VFX;
    public Text ResultAlert;

    public int Score;
    public Text ScoreText;

    public string[] QuestionText;
    public int[] RightOption;
    public Text CurrentQuestionDisplay;
    public static SolarSystemGameManager Instance;

    public Question[] questions;
    public int[] perstagequestionsnumber;

    public int CurrentQuestionIndex;

    public int stars;
    public Text starText;


    public float maxTime = 60f; // Set the maximum time for the timer in seconds.
    [SerializeField] private float currentTime;
    private float starTime;
    public Image fillBar;
    public Text timerText;

    public Image stagefillBar;
    public int totalquesetion;

    public int stageIndex;
    public int perStageQuestionCounter;

    public Text DreamCoins;

    bool gameEnded = false;
    [SerializeField] GameObject SummerPanel;
    [SerializeField] GameObject LoadingPanel;

    [SerializeField] GameObject PlanetName;
    [SerializeField] Text PlanetNameText;

    public bool takeMouseInput = true;

    int currentLevel;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //StartGame();
        gameEnded = true;
        LoadingPanel.SetActive(true);
    }

    public void StartGame()
    {
        TakEMouseInput();
        currentTime = maxTime;
        SummerPanel.SetActive(false);
        starTime = 15;
        stars = 3;

        ScoreText.text = Score.ToString();
        starText.text = stars.ToString();

        CurrentQuestionIndex = 0;

        SetCurrentLevel();
        Debug.Log("Displayed from here");

        DisplayNextQuestion();


        if (PrefsHandler.instance)
            DreamCoins.text = PrefsHandler.instance.GetDreamCoins().ToString();

        gameEnded = false;
    }

    void SetCurrentLevel()
    {

        if (PlayerPrefs.GetInt("SolarSystemLevel", 0) == 1 || PlayerPrefs.GetInt("SolarSystemLevel", 0) == 0)
        {
            currentLevel = 1;
            CurrentQuestionIndex = 0;
        }
        else if (PlayerPrefs.GetInt("SolarSystemLevel", 0) == 2)
        {
            currentLevel = 2;
            CurrentQuestionIndex = 3;
        }
        else if (PlayerPrefs.GetInt("SolarSystemLevel", 0) == 3)
        {
            currentLevel = 3;
            CurrentQuestionIndex = 7;
        }
        else if (PlayerPrefs.GetInt("SolarSystemLevel", 0) == 4)
        {
            currentLevel = 4;
            CurrentQuestionIndex = 12;
        }
        else if (PlayerPrefs.GetInt("SolarSystemLevel", 0) == 5)
        {
            currentLevel = 5;
            CurrentQuestionIndex = 18;
        }
        else if (PlayerPrefs.GetInt("SolarSystemLevel", 0) == 6)
        {
            currentLevel = 6;
            CurrentQuestionIndex = 25;
        }
        else if (PlayerPrefs.GetInt("SolarSystemLevel", 0) == 7)
        {
            currentLevel = 7;
            CurrentQuestionIndex = 26;
        }
        else if (PlayerPrefs.GetInt("SolarSystemLevel", 0) == 8)
        {
            currentLevel = 8;
            CurrentQuestionIndex = 27;
        }
        else if (PlayerPrefs.GetInt("SolarSystemLevel", 0) == 9)
        {
            currentLevel = 9;
            CurrentQuestionIndex = 28;
        }
        else if (PlayerPrefs.GetInt("SolarSystemLevel", 0) == 10)
        {
            currentLevel = 10;
            CurrentQuestionIndex = 29;
        }
    }
    public void DisplayNextQuestion()
    {
        CurrentQuestionDisplay.text = questions[CurrentQuestionIndex].QuestionText;
    }

    IEnumerator DisplayThenStopAlert(string str,float timeNow,int type)// string to display, hide after this time, text color index
    {
        ResultAlert.gameObject.SetActive(true);
        ResultAlert.text = str;

        if(type == 1) // Good
        {
            ResultAlert.color = Color.green;
            SoundManager.instance.AudioSource.PlayOneShot(SoundManager.instance.RightSound);
        }
        else if(type == 2)// Bad
        {
            ResultAlert.color = Color.red;
            SoundManager.instance.AudioSource.PlayOneShot(SoundManager.instance.WrongSound);
        }

        yield return new WaitForSeconds(timeNow);// kitne time tak str likha ae bas 


        ResultAlert.gameObject.SetActive(false);
    }



    public void CheckAnswer(int num)
    {
        Debug.Log("Index: " + num);
        if (questions[CurrentQuestionIndex].RightOption == num)//agr wo answer theek ha
        {
            PlanetNameAssign(num);

            SoundManager.instance.AudioSource.PlayOneShot(SoundManager.instance.RightSound);
            Debug.Log("Right Answer");
            Score = Score + 10;
            CurrentQuestionIndex++;//index ko plus
            StartCoroutine(DisplayThenStopAlert("RIGHT ANSWER !", (float)2, 1));
            perStageQuestionCounter++;
            stagefillBar.fillAmount = (float)((float)perStageQuestionCounter / (float)perstagequestionsnumber[stageIndex]);

            if (questions.Length <= CurrentQuestionIndex)// agr age question nhi hain //Changed from >=
            {
                Debug.Log("Game win called from here");
                Debug.Log("Inside this");
                GameWin();
            }
            else if (perstagequestionsnumber[stageIndex] == perStageQuestionCounter)//pehle stage ke agr sare sawal pure ho gae
            {
                stagefillBar.fillAmount = 0.05f;
                stageIndex++;
                perStageQuestionCounter = 0;

                StartCoroutine(DisplayThenStopAlert("READY FOR NEXT STAGE!", (float)3, 1));

                Debug.Log("Displayed from here");

                DisplayNextQuestion();//agla question dikhao
                Debug.Log("Inside this haseeb");
                WinSequence();
            }
            else
            {
                Debug.Log("Inside this");

                //WinSequence();
                DisplayNextQuestion();//agla question dikhao
            }
        }
        else
        {
            if (Score >= 2)
            {
                Score = Score - 2;
            }
            if (Score < 0)
                Score = 0;
            StartCoroutine(DisplayThenStopAlert("WRONG ANSWER !", (float)1, 2));
            Debug.Log("Wrong Answer");
        }
        ScoreText.text = Score.ToString();
    }

    private void PlanetNameAssign(int num)
    {
        PlanetNameText.text = questions[CurrentQuestionIndex].ToString();
        switch (num)
        {
            case 0:
                PlanetNameText.text = "MERCURY";
                break;
            case 1:
                PlanetNameText.text = "VENUS";
                break;
            case 2:
                PlanetNameText.text = "MARS";
                break;
            case 3:
                PlanetNameText.text = "EARTH";
                break;
            case 4:
                PlanetNameText.text = "JUPITER";
                break;
            case 5:
                PlanetNameText.text = "SATURN";
                break;
            case 6:
                PlanetNameText.text = "URANUS";
                break;
            case 7:
                PlanetNameText.text = "NEPTUNE";
                break;
            case 8:
                PlanetNameText.text = "PLUTO";
                break;
            default:
                break;
        }
        PlanetName.SetActive(true);
        Invoke("DisablePlanetName", 2f);
    }
    void DisablePlanetName()
    {
        PlanetName.SetActive(false);
    }

    private void WinSequence()
    {
        Debug.Log("Inside this");

        #region Assinging level question limitations
        int minusLength = 0;
        if (currentLevel == 1 )
        {
            minusLength = 51;
        }
        else if (currentLevel == 2)
        {
            minusLength = 47;
        }
        else if (currentLevel == 3)
        {
            minusLength = 42;
        }
        else if (currentLevel == 4)
        {
            minusLength = 36;
        }
        else if (currentLevel == 5)
        {
            minusLength = 30;
        }
        else if (currentLevel == 6)
        {
            minusLength = 24;
        }
        else if (currentLevel == 7)
        {
            minusLength = 18;
        }
        else if (currentLevel == 8)
        {
            minusLength = 12;
        }
        else if (currentLevel == 9)
        {
            minusLength = 6;
        }
        else if (currentLevel == 10)
        {
            minusLength = 0;
        }
        #endregion

        if (CurrentQuestionIndex >= questions.Length - minusLength)
        {
            Debug.Log("Game win called from here");
            Debug.Log("Inside this");

            GameWin();
        }
        else
        {
            Debug.Log("Displayed from here");
            
            DisplayNextQuestion();//agla question dikhao
        }
    }

    private void Update()
    {
        if (!gameEnded && takeMouseInput) 
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;

                starTime -= Time.deltaTime;
                if (starTime <= 0)
                {
                    starTime = 15;
                    stars--;
                    starText.text = stars.ToString();
                }
                UpdateFillBar();
                UpdateTimerText();
            }
            else
            {
                // Time is up, handle what happens when the timer reaches 0.
                // For example, you can end the game or trigger an event.

                currentTime = 0;
                if (CurrentQuestionIndex < questions.Length)
                    GameFail();
            }
        }
        
    }

    private void UpdateFillBar()
    {
        fillBar.fillAmount = currentTime / maxTime;
        //Debug.Log("Fill amount: " + fillBar.fillAmount);
    }

    private void UpdateTimerText()
    {
        timerText.text = currentTime.ToString("F0"); // Display time without decimals.
    }

    public void GameWin()
    {
        #region Setting stage prefs
        if (PlayerPrefs.GetInt("SolarSystemLevel", 0) == 1 || PlayerPrefs.GetInt("SolarSystemLevel", 0) == 0)
        {
            PlayerPrefs.SetInt("SolarSystemLevel", 2);
        }
        else
        {
            PlayerPrefs.SetInt("SolarSystemLevel", PlayerPrefs.GetInt("SolarSystemLevel", 0) + 1);
        }
        #endregion

        gameEnded = true;
        Score = Score * stars;
        ScoreText.text = Score.ToString();
        PrefsHandler.instance.AddDreamCoins(50);
        Debug.Log("Dream coins: " + PrefsHandler.instance.GetDreamCoins());
        DreamCoins.text = PrefsHandler.instance.GetDreamCoins().ToString();

        // Show Summer Screen 
        StopTakingMouseInput();
        SummerPanel.SetActive(true);
        SumerPanelReferences summerRef = SummerPanel.GetComponent<SumerPanelReferences>();
        summerRef.WinPanel.SetActive(true);
        summerRef.UpdateStarEarned(stars);
        summerRef.LosePanel.SetActive(false);
        summerRef.DreamCoins.text =  PrefsHandler.instance.GetDreamCoins().ToString();
    }

    public void GameFail()
    {
        StopTakingMouseInput();
        // Show Summer Screen 
        SummerPanel.SetActive(true);
        SumerPanelReferences summerRef = SummerPanel.GetComponent<SumerPanelReferences>();
        summerRef.WinPanel.SetActive(false);
        summerRef.LosePanel.SetActive(true);
        summerRef.NextButton.SetActive(false);
        summerRef.DreamCoins.text = PrefsHandler.instance.GetDreamCoins().ToString();
    }

    public void CloseDummyLoading()
    {
        takeMouseInput = true;
        Debug.Log("close dummy");
        LoadingPanel.SetActive(false);
        StartGame();
    }

    public void LoadMenuScene()
    {
        AudioSourceManager.Instance.PlayClickSFX("SolorSystem");
        SceneManager.LoadSceneAsync("Menu");
        AudioSourceManager.Instance.ChangeSceneBGMusic(0);
    }


    public void StopTakingMouseInput()
    {
        takeMouseInput = false;
    } 
    
    public void TakEMouseInput()
    {
        takeMouseInput = true;
     //   AudioSourceManager.Instance.PlayClickSFX("SolorSystem");
    }
}
