using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickButtonEventScript : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UIControllerScript.UIController.ActivateSelectPanel(eventData.pointerCurrentRaycast.gameObject);
    }
}
