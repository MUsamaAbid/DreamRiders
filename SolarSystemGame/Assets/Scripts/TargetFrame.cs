using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrame : MonoBehaviour
{
    [SerializeField] int Target = 30;
    private void Awake()
    {
        Application.targetFrameRate = Target;
    }
}
