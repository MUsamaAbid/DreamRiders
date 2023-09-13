using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DummyLoading : MonoBehaviour
{
    [SerializeField] Image LoadingImage;
    [SerializeField] TMP_Text LoadingText;
    private void Start()
    {
        StartCoroutine(StartLoading());
    }
    IEnumerator StartLoading()
    {
        while(LoadingImage.fillAmount != 100)
        {
            LoadingImage.fillAmount += Time.deltaTime * 5;
            LoadingText.text = "Loading  " +  Mathf.Round((LoadingImage.fillAmount/1 * 100)).ToString() + "%";   
            yield return new WaitForSeconds(0.5f);
        }
        
        yield return null;
    }

    private void Update()
    {
        if (LoadingImage.fillAmount == 1)
        {
            if(SolarSystemGameManager.Instance)
                SolarSystemGameManager.Instance.CloseDummyLoading();
            if (GameManager.Instance)
                GameManager.Instance.CloseLoadPanel();
        }
            
    }
}
