using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ModeScreen : MonoBehaviour
{
    [SerializeField] Text DreamCoinsText;
    [SerializeField] Text totalCoins;
    [SerializeField] List<Button> modeScreenButtons = new List<Button>();

    private void Start()
    {
        for(int i = 0; i < modeScreenButtons.Count; i++)
        {
            modeScreenButtons[i].onClick.AddListener(() =>
            {
                AudioSourceManager.Instance.PlayClickSFX("Menu");
            });
        }
    }
    private void OnEnable()
    {
        if (!PrefsHandler.instance) Debug.Log("No Prefs handler found");
        DreamCoinsText.text = PrefsHandler.instance.GetDreamCoins().ToString();
        totalCoins.text = PrefsHandler.instance.GetDreamCoins().ToString();
    }
    public void OpenGameMode()
    {
        Instantiate(ScreenManager.Instance.LevelScreen);
        Destroy(this.gameObject);
    }
    public void Back()
    {
        Instantiate(ScreenManager.Instance.MainScreen);
        Destroy(this.gameObject);
    }
}
