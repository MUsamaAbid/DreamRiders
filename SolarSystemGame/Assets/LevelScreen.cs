using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class LevelScreen : MonoBehaviour
{
    [SerializeField] Text totalCoins;

    private void Start()
    {
       
    }
    private void OnEnable()
    {
        if (!PrefsHandler.instance) Debug.Log("No Prefs handler found");
        totalCoins.text = PrefsHandler.instance.GetDreamCoins().ToString();
    }
    public void OpenLevel(int num)
    {
        AudioSourceManager.Instance.PlayClickSFX("Menu");
        if(!AudioSourceManager.Instance.IsMusicPlaying)
            AudioSourceManager.Instance.MuteSound("Music");

        AudioSourceManager.Instance.ChangeSceneBGMusic(num);
        SceneManager.LoadSceneAsync(num);
    }
    public void Back()
    {
        AudioSourceManager.Instance.PlayClickSFX("Menu");
        Instantiate(ScreenManager.Instance.ModeScreen);
        Destroy(this.gameObject);
    }
}

