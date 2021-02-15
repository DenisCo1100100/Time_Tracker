using UnityEngine;
using UnityEngine.UI;

public class AddingTimersScript : MonoBehaviour
{
    [SerializeField] private GameObject _timerPrefab;
    [SerializeField] private InputField _inputTimerNameText;
    [SerializeField] private GameObject _content;

    public void AddTimer()
    {
        var newtimer = Instantiate(_timerPrefab);
        newtimer.transform.SetParent(_content.transform);
        newtimer.transform.Find("TimerNameText").GetComponent<Text>().text = _inputTimerNameText.text;
        newtimer.transform.Find("LogoImage").GetComponent<Image>().sprite = SelectLogo.selectLogo.IconSprite;
    }

    public void DefaultState()
    {
        _inputTimerNameText.text = "";
        SelectLogo.selectLogo.DefaultState();
    }
}