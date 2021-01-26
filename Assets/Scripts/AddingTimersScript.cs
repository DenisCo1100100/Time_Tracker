using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddingTimersScript : MonoBehaviour
{
    [SerializeField] private GameObject TimerPrefab;
    [SerializeField] private InputField inputTimerNameText;
    [SerializeField] private GameObject content;

    public void AddTimer()
    {
        var newtimer = Instantiate(TimerPrefab);
        newtimer.transform.SetParent(content.transform);
        newtimer.transform.Find("TimerNameText").GetComponent<Text>().text = inputTimerNameText.text;
    }
}