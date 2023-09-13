using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ZoomController ZoomManager;
    [SerializeField] GameObject LevelCompletion;
    [SerializeField] TMP_Text ScoreTxt;
    [SerializeField] int Score = 0;
    [SerializeField] GameObject LoadingPanel;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != null)
            DestroyImmediate(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

        LoadingPanel.SetActive(true);
    }
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
        AudioSourceManager.Instance.ChangeSceneBGMusic(0);
    }

    public void GameEnd()
    {
        references LvlCompeletionref = LevelCompletion.GetComponent<references>();
        PrefsHandler.instance.AddDreamCoins(Score);
       
        LvlCompeletionref.Coins.text = PrefsHandler.instance.GetDreamCoins().ToString();
        LvlCompeletionref.Scrore.text = Score.ToString();
        LevelCompletion.SetActive(true);
    }

    public void SetGameLevel()
    {
        //everyGameLevel will have 10 flags and every 10 flags will be first 10 
       
        int LevelNumber = PrefsHandler.instance.GetGameLevel() +  1;
        FlagManager.Instance.SetUpFlagsforCurrentLevl(LevelNumber * 10);
    }


    public void GameLevelCompleted()
    {

    }
    public void UpdateScore()
    {
        Score += 10;
        ScoreTxt.text = Score.ToString();
        CheckLevelFinish();
    }

    void CheckLevelFinish()
    {
        if(FlagManager.Instance.FlagParentTransfrom.childCount <= 0)
        {
            Debug.Log("LevelEnded");
            GameEnd();
        }
    }

    public void ReTry()
    {
        PrefsHandler.instance.RemoveDreamCoins(Score);
        AudioSourceManager.Instance.PlayClickSFX("WorldMap");
        Score = 0;
        SetGameLevel();
        LevelCompletion.SetActive(false);
    }

    public void Next()
    {
        PrefsHandler.instance.SetGameLevel(1);
        AudioSourceManager.Instance.PlayClickSFX("WorldMap");
        BackToMenu();
    }

    public void CloseLoadPanel()
    {
        LoadingPanel.SetActive(false);
        SetGameLevel();
    }
}
