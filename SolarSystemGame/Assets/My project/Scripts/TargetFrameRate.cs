using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
    [SerializeField] int TargetFrame;
    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 20;
    }

}
