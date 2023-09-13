using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject MainScreen;
    public GameObject LevelScreen;
    public GameObject ModeScreen;
    public GameObject LevelWinScreen;
    public GameObject LevelLoseScreen;
    public GameObject AlertScreen;


    public static ScreenManager Instance;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame

  

}
