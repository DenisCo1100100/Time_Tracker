using UnityEngine;
using UnityEngine.UI;

public class UIMenuPanel : MonoBehaviour
{
    #region Inspector
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _button;
    #endregion

    public string NamePanelMenu { get { return _panel.name; } }
    public string NameButtonMenu { get { return _button.name; } }
    public bool IsActiveMenu { get { return _panel.activeSelf; } }

    public void SetActive(bool value)
    {
        _panel.SetActive(value);
        _button.GetComponent<Button>().interactable = !value;
    }
}
