using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects Instance;
    [SerializeField] AudioSource audioManager;
    [SerializeField] List<AudioClip> clips = new List<AudioClip>();


    private void Start()
    {
        Instance = this;
    }
    public void IncorrectSelectionSound()
    {
        audioManager.PlayOneShot(clips[1]);
    }
    public void CorrectSelectionSound()
    {
        audioManager.PlayOneShot(clips[2]);
    }
}
