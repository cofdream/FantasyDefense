using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class UIStart : MonoBehaviour, IMoveHandler
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] Button btnStart;
    [SerializeField] Button btnContuin;
    [SerializeField] Button btnOptions;
    [SerializeField] Button btnQuit;


    private void Awake()
    {
        canvasGroup.alpha = 0;

        btnStart.onClick.AddListener(BtnStart);
        btnContuin.onClick.AddListener(BtnContuin);
        btnOptions.onClick.AddListener(BtnOptions);
        btnQuit.onClick.AddListener(BtnQuit);

        SelectSelectable(btnStart);
    }

    private void OnDestroy()
    {
        btnStart.onClick.RemoveListener(BtnStart);
        btnContuin.onClick.RemoveListener(BtnContuin);
        btnOptions.onClick.RemoveListener(BtnOptions);
        btnQuit.onClick.RemoveListener(BtnQuit);
    }

    private void BtnStart()
    {
        Command.EnterGame();
    }
    private void BtnContuin()
    {
        Command.ContuinGame();
    }
    private void BtnOptions()
    {

    }
    private void BtnQuit()
    {
        Command.QuitGame();
    }


    public void Show()
    {
        canvasGroup.alpha = 1;
    }
    public void Hide()
    {
        canvasGroup.alpha = 0;
    }

    public void OnMove(AxisEventData eventData)
    {
        Debug.Log(1);
    }


    private void SelectSelectable(Selectable selectable)
    {
        var eventSystem = FindObjectOfType<EventSystem>();
        btnStart.OnSelect(new BaseEventData(eventSystem) { selectedObject = btnStart.gameObject });
    }
}