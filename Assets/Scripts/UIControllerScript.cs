using System.Collections.Generic;
using UnityEngine;

public class UIControllerScript : MonoBehaviour
{
    [SerializeField] private List<UIMenuPanel> _allMenuPanels;

    public static List<TimerController> AllTimers;
    public static UIControllerScript UIController;

    private void Awake()
    {
        UIController = this;
        AllTimers = new List<TimerController>();
    }

    public void ActivateSelectPanel(GameObject selectButton)
    {
        foreach (var panel in _allMenuPanels)
        {
            if (selectButton.name != panel.NameButtonMenu)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }
    }
}
