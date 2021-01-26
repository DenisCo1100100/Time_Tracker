using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Start()
    {
        timeCounter = gameObject.transform.Find("TimerText").GetComponent<Text>();
        timeCounter.text = "00:00:00";
        timerGoing = false;
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void StartStopTimer()
    {
        if(timerGoing == false)
        {
            timerGoing = true;

            StartCoroutine(UpdateTimer());
        }
        else
        {
            timerGoing = false;
        }
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "" + timePlaying.ToString("hh':'mm':'ss");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}