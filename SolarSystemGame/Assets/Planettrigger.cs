using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planettrigger : MonoBehaviour
{
    public string PlanetName;
    public int planetIndex;
    public GameObject Glow;
    private void OnMouseDown()
    {
        if (SolarSystemGameManager.Instance.takeMouseInput)
        {
            SolarSystemGameManager.Instance.CheckAnswer(planetIndex);
            Instantiate(SolarSystemGameManager.Instance.VFX, this.transform.position, Quaternion.identity);
            Glow.SetActive(true);
        }
    }


    public void OnMouseUp()
    {
        if (SolarSystemGameManager.Instance.takeMouseInput)
            Glow.SetActive(false);
    }


    private void OnMouseEnter()
    {
        if (SolarSystemGameManager.Instance.takeMouseInput)
            Glow.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (SolarSystemGameManager.Instance.takeMouseInput)
            Glow.SetActive(false);
    }
}
