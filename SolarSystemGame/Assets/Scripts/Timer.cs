using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    #region Instance
    public static Timer instance;
    public void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] Image timerFillbar;
    [SerializeField] GameObject ClockHand;
    float barDivision;

    
    public float totalTime = 120.0f; // Total time for the countdown in seconds
    private float remainingTime;   // Current remaining time

    public Text timerText; // Reference to a UI Text element to display the timer

    public UnityEngine.Events.UnityEvent onTimerEnd; // Event to trigger when the timer ends

    bool stopTimer;
    private void Start()
    {
        stopTimer = false;
        //timerFillbar.fillAmount = 0;
        barDivision = 1 / totalTime;

        remainingTime = totalTime;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (!stopTimer)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;

                UpdateTimerDisplay();

                if (remainingTime <= 0)
                {
                    remainingTime = 0;
                    UpdateTimerDisplay();
                    TimerEnded();
                }
            }
        }
    }

    void UpdateTimerDisplay()
    {
        //Debug.Log("Timer: " + FormatTime(remainingTime));
        //timerFillbar.fillAmount = (totalTime - remainingTime) / totalTime;
        float division = 360 / totalTime;
        ClockHand.transform.rotation = Quaternion.Euler(0, 0, -(totalTime - remainingTime) * division);
        if (timerText != null)
        {
            timerText.text = FormatTime(remainingTime);
        }
    }
    public void SubmitDrawing()
    {
        
        StopTimer();
        SummaryScreen.instance.UpdateTimeText(FormatTime(totalTime - remainingTime).ToString());
        SummaryScreen.instance.SetTimePassed(remainingTime);
        SummaryScreen.instance.StartGameEndSequence();
    }
    void TimerEnded()
    {
        AudioSourceManager.Instance.TimerGoesOFF();
        //IndieStudio.DrawingAndColoring.Logic.SoundManager.Instance.PlayTimer(); ;
        StopTimer();
        SummaryScreen.instance.SetTimePassed(0);
        SummaryScreen.instance.StartGameEndSequence();
        SummaryScreen.instance.UpdateTimeText(FormatTime(totalTime - remainingTime).ToString());
        if (onTimerEnd != null)
        {
            onTimerEnd.Invoke();
        }
    }
    public void RestartTimer()
    {
        StopTimer();
        ResetTimer();
        StartTimer();
    }
    public void ResetTimer()
    {
        StopTimer();
        barDivision = 1 / totalTime;

        remainingTime = totalTime;
        UpdateTimerDisplay();
    }
    public void StartTimer()
    {
        stopTimer = false;
    }
    public void StopTimer()
    {
        stopTimer = true;
    }
    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}