using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour, IUIPanel
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] Button IllustratedBookButton;
    [SerializeField] Button PetButton;
    [SerializeField] Button BackpackButton;
    [SerializeField] Button PilotButton;
    [SerializeField] Button UserButton;
    [SerializeField] Button SaveButton;
    [SerializeField] Button SetUpButton;
    [SerializeField] Button QuitButton;

    public void Hide()
    {
        canvasGroup.alpha = 0;
    }

    public void Init(IView view)
    {

    }

    public void Show()
    {
        SelectSelectable(IllustratedBookButton);
        canvasGroup.alpha = 1;
    }

    public void Start()
    {
        Hide();

        QuitButton.onClick.AddListener(Hide);
    }

    public void SwitchActive()
    {
        canvasGroup.alpha = canvasGroup.alpha == 0 ? 1 : 0;
    }

    private void SelectSelectable(Selectable selectable)
    {
        var eventSystem = FindObjectOfType<EventSystem>();
        IllustratedBookButton.OnSelect(new BaseEventData(eventSystem) { selectedObject = IllustratedBookButton.gameObject });
    }
}
//图鉴
//精灵
//背包
//领航员
//用户名
//保存
//设置
//退出

//Illustrated Book
//Pet
//Backpack
//pilot
//username
//save
//set up
//quit