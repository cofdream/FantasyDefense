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
        view.StartBtn.onClick.AddListener(StartBtn);
        view.ContuineBtn.onClick.AddListener(ContuineBtn);
        view.InfoBtn.onClick.AddListener(InfoBtn);
        view.QuitBtn.onClick.AddListener(this.QuiteBtn);
        //UIGlobalEvent.Dispatcher.Add((byte)UIEventType.OpenMainView, OpenView);
    }
    private void DisposeView()
    {
        view.StartBtn.onClick.RemoveListener(StartBtn);
        view.ContuineBtn.onClick.RemoveListener(ContuineBtn);
        view.InfoBtn.onClick.RemoveListener(InfoBtn);
        view.QuitBtn.onClick.RemoveListener(QuiteBtn);
        //UIGlobalEvent.Dispatcher.Remove((byte)UIEventType.OpenMainView, OpenView);

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

    void StartBtn()
    {
        Hide();
        UIPanelFactory.ShowPanel(UIPanelType.BattleView);
        BattleManager.Instance.StartBattle();
    }
    void OpenView(byte type)
    {
        //Hide();
        //UIPanelFactory.ShowPanelAsync(UIPanelType.ArchivesView);
    }
    void ContuineBtn()
    {
        Hide();
        //加载上次的存档
    }
    void InfoBtn()
    {
        Hide();
    }
    void QuiteBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.isPlaying = false;
#endif
    }
}