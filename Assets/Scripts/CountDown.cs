using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public TMP_Text countDownText;
    public float countDownTimeMins;
    public float countDownTimeSecs;
    public float timeRemaining;
    public bool timerRunning;

    private void OnValidate()
    {
        if (countDownTimeMins > 0)
        {
            countDownTimeSecs = countDownTimeMins * 60;
        }
    }

    void Start()
    {
        if (countDownTimeMins > 0)
        {
            countDownTimeSecs = countDownTimeMins * 60;
        }

        timeRemaining = countDownTimeSecs;
    }

    void Update()
    {
        DisplayTime(timeRemaining);

        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        countDownText.text = minutes + ":" + seconds.ToString("00");
    }
}
