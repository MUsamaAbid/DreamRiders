using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] Text totalCoins;
    [SerializeField] List<Button> MenuButtons = new List<Button>();
    // Start is called before the first frame update
    private void Start()
    {
        for(int i =0; i < MenuButtons.Count; i++)
        {
            MenuButtons[i].onClick.AddListener(() =>
            {
                AudioSourceManager.Instance.PlayClickSFX("Menu");
            });
        }
       
    }
    public void Play()
    {
        AudioSourceManager.Instance.PlayClickSFX("Menu");
        Instantiate(ScreenManager.Instance.ModeScreen);
        Destroy(this.gameObject);
    }
    private void OnEnable()
    {
        if (!PrefsHandler.instance)
            Debug.Log("No Prefs handler found");
        else
        {
            if(totalCoins)
                totalCoins.text = PrefsHandler.instance.GetDreamCoins().ToString();
        }
    }
    public void Exit()
    {
        AudioSourceManager.Instance.PlayClickSFX("Menu");
        Application.Quit();
    }

    public void OnVolumeUpdated(string Volumetype)
    {
        AudioSourceManager.Instance.OnChangeVolume(Volumetype);
    }
}
