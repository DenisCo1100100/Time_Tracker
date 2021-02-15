using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private Text _timeCounter;

    private TimeSpan _timePlaying;
    private bool _timerGoing;

    private float _elapsedTime;
    
    private DateTime _stopPointTime;
    private DateTime _starPointTime;

    private Image playStopImage;

    private void Start()
    {
        _timeCounter = gameObject.transform.Find("TimerText").GetComponent<Text>();
        _timeCounter.text = "00:00:00";
        _timerGoing = false;

        Application.runInBackground = true;

        UIControllerScript.AllTimers.Add(this);

        playStopImage = gameObject.transform.Find("PlayStopImage").GetComponent<Image>();
    }

    public void BeginTimer()
    {
        foreach (TimerController timer in UIControllerScript.AllTimers)
        {
            timer.EndTimer();
        }

        _timerGoing = true;

        StartCoroutine(UpdateTimer());
        playStopImage.sprite = Resources.Load<Sprite>("Stop");
    }

    public void StartStopTimer()
    {
        if(_timerGoing == false)
        {
            BeginTimer();
        }
        else
        {
            EndTimer();
        }
    }

    public void EndTimer()
    {
        _timerGoing = false;

        playStopImage.sprite = Resources.Load<Sprite>("Play");
    }

    private IEnumerator UpdateTimer()
    {
        while (_timerGoing)
        {
            _elapsedTime += Time.deltaTime;
            _timePlaying = TimeSpan.FromSeconds(_elapsedTime);
            string timePlayingStr = "" + _timePlaying.ToString("hh':'mm':'ss");
            _timeCounter.text = timePlayingStr;

            yield return null;
        }
    }

    private void OnDisable()
    {
        if (_timerGoing == true)
        {
            _stopPointTime = DateTime.Now;
        }
    }

    private void OnEnable()
    {
        if (_timerGoing == true)
        {
            _starPointTime = DateTime.Now;
            _elapsedTime += (_starPointTime - _stopPointTime).Seconds;

            BeginTimer();
        }
    }
}