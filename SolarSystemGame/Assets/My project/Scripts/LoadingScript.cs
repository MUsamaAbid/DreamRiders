using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    [SerializeField] Text LoadingText;
    [SerializeField] Image fillbar;
    private void OnEnable()
    {
        LoadingText.text = "0%";
        Invoke("Disable", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        LoadingText.text = (int)(fillbar.fillAmount * 100) + "%";
    }
    void Disable()
    {
        gameObject.SetActive(false);
    }
}
