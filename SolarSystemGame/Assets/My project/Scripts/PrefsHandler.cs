using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsHandler : MonoBehaviour
{
    public static PrefsHandler instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddDreamCoins(int coins)
    {
        PlayerPrefs.SetInt("DreamCoins", PlayerPrefs.GetInt("DreamCoins", 0) + coins);
    } 
    public void RemoveDreamCoins(int coins)
    {
        PlayerPrefs.SetInt("DreamCoins", PlayerPrefs.GetInt("DreamCoins", 0) - coins);
    }

    public int GetDreamCoins()
    {
        return PlayerPrefs.GetInt("DreamCoins");
    }

    public void SetGameLevel(int level)
    {
        PlayerPrefs.SetInt("MapsLevel", PlayerPrefs.GetInt("MapsLevel", 0) + level);
    }

    public int GetGameLevel()
    {
        return PlayerPrefs.GetInt("MapsLevel", 0);
    }


}
