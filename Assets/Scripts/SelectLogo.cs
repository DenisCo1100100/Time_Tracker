using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLogo : MonoBehaviour
{
    [SerializeField] private List<GameObject> _iconList;
    public Sprite IconSprite { get; private set; }
    public static SelectLogo selectLogo;

    private void Awake()
    {
        selectLogo = this;

        IconSprite = _iconList[0].GetComponent<Image>().sprite;
        _iconList[0].GetComponent<Image>().color = new Color(0f, 0f, 0f, 1);
    }

    public void SelectIcon(GameObject thisButton)
    {
        foreach (var button in _iconList)
        {
            button.GetComponent<Image>().color = new Color(0f, 0f, 0f, 100/255f);
        }

        thisButton.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1);
        IconSprite = thisButton.GetComponent<Image>().sprite;
    }

    public void DefaultState()
    {
        SelectIcon(_iconList[0]);
    }
}
