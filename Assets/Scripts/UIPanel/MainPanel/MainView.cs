using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class MainView : ViewBase,
    IMoveHandler, ICancelHandler, IPointerClickHandler,ISelectHandler
{
    public Button ContuineBtn;
    public Button StartBtn;
    public Button InfoBtn;
    public Button QuitBtn;



    public void OnMove(AxisEventData eventData)
    {
        Debug.Log(eventData.moveVector);
    }

    public void OnCancel(BaseEventData eventData)
    {
        Debug.Log("Cancel");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnClick");
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Select");
    }
}
