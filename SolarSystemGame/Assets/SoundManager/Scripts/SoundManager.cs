using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieStudio.DrawingAndColoring.Utility;

namespace IndieStudio.DrawingAndColoring.Logic
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;


        /// <summary>
        /// The Click SFX audioClip.
        /// </summary>
        public AudioClip ClickSFX;
        public AudioClip TimerSFX;


        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            DontDestroyOnLoad(Instance);
        }


        public void PlayClickSFX()
        {
            //Debug.Log("PlaySfx");
            AudioSources.instance.SFXAudioSource().PlayOneShot(ClickSFX);
        }

        public void PlayTimer()
        {
            //Debug.Log("PlaySfx");
            AudioSources.instance.SFXAudioSource().PlayOneShot(TimerSFX);
        }

    }
}
