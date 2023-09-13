using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSourceManager : MonoBehaviour
{
    public static AudioSourceManager Instance;
    [SerializeField] AudioSource MusicAudioSource;
    [SerializeField] AudioSource SFXAudioSource;    
    [SerializeField] Slider MusicAudioSlider;
    [SerializeField] Slider SFXAudioSlider;
    [SerializeField] List<AudioClip> AudioClips = new List<AudioClip>();
    public bool IsMusicPlaying = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        DontDestroyOnLoad(Instance);
    }

    public void ChangeSceneBGMusic(int num)
    {
        switch(num)
        {
            case 0:
                MusicAudioSource.Stop();
                MusicAudioSource.PlayOneShot(AudioClips[0]);
                break;
            case 1:
                MusicAudioSource.Stop();
                MusicAudioSource.PlayOneShot(AudioClips[1]);
                break;
            case 2:
                MusicAudioSource.Stop();
                MusicAudioSource.PlayOneShot(AudioClips[2]);
                break;
            case 3:
                MusicAudioSource.Stop();
                MusicAudioSource.PlayOneShot(AudioClips[3]);
                break;
        }
    }

    public void PlayClickSFX(string name)
    {

        //SFXAudioSource.PlayOneShot(AudioClips[4]);
        switch (name)
        {
            case "Menu":
                SFXAudioSource.Stop();
                SFXAudioSource.PlayOneShot(AudioClips[4]);
                break;
            case "SolorSystem":
                SFXAudioSource.Stop();
                SFXAudioSource.PlayOneShot(AudioClips[5]);
                break;
            case "DrawingColor":
                SFXAudioSource.Stop();
                SFXAudioSource.PlayOneShot(AudioClips[6]);
                break;    
            case "WorldMap":
                SFXAudioSource.Stop();
                SFXAudioSource.PlayOneShot(AudioClips[7]);
                break;    
        }
    }

    public void MuteSound(string type)
    { 
        if(type == "Music")
        {
            if (MusicAudioSource.mute == true)
            {
                MusicAudioSource.mute = false;
                IsMusicPlaying = true; ;
            }
            else
            {
                MusicAudioSource.mute = true;
                IsMusicPlaying = false;
            }
        }
        else if( type == "Sound")
        {
            if (MusicAudioSource.mute == true)
            {
                SFXAudioSource.mute = false;
            }
            else
            {
               SFXAudioSource.mute = true;
            }
        }
        
    }

    public void OnChangeVolume(string type)
    {
        switch (type)
        {
            case "Music":
                MusicAudioSource.volume = MusicAudioSlider.value;
                break;

            case "Sound":
                SFXAudioSource.volume = SFXAudioSlider.value;
                break;
        }
    }

    public void TimerGoesOFF()
    {
        SFXAudioSource.Stop();
        SFXAudioSource.PlayOneShot(AudioClips[8]);
    }
}
