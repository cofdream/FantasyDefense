using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MainPanel : IUIPanel
{
    private MainView view;

    private bool isAcrchive;
    public void Init(IView view)
    {
        this.view = view as MainView;
        InitView();
    }

    private void InitView()
    {
        view.StartBtn.onClick.AddListener(Hide);
        view.ContuineBtn.onClick.AddListener(Contuine);
        view.InfoBtn.onClick.AddListener(Info);
        view.QuitBtn.onClick.AddListener(this.OnQuiteBtn);
        UIGlobalEvent.Dispatcher.Add((byte)UIEventType.OpenMainView, OpenView);
    }
    private void DisposeView()
    {
        view.StartBtn.onClick.RemoveListener(Hide);
        view.ContuineBtn.onClick.RemoveListener(Contuine);
        view.InfoBtn.onClick.RemoveListener(Info);
        view.QuitBtn.onClick.RemoveListener(OnQuiteBtn);
        UIGlobalEvent.Dispatcher.Remove((byte)UIEventType.OpenMainView, OpenView);

        view = null;
    }


    public void Show()
    {
        view.Show();

        view.ContuineBtn.interactable = isAcrchive = Archives.AllArchive.Count == 0;
    }
    public void Hide()
    {
        view.Hide();

    }


    void OpenView(byte type)
    {
        Hide();
        UIPanelFactory.ShowPanelAsync(UIPanelType.ArchivesView);
    }
    void Contuine()
    {
        Hide();
        //加载上次的存档
    }
    void Info()
    {
        Hide();
    }
    void OnQuiteBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.isPlaying = false;
#endif
    }
}