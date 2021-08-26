using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchivePanel : IUIPanel
{
    private ArchivesView view;

    private int selectIndex;


    public void Init(IView view)
    {
        this.view = view as ArchivesView;
        InitView();
    }
    private void InitView()
    {
        view.CloseBtn.onClick.AddListener(CloseView);

        UIGlobalEvent.Dispatcher.Add((byte)UIEventType.OpenArchivesView, OpenView);

        var archives = Archives.AllArchive;
        int length = archives.Count;
        for (int i = 0; i < length; i++)
        {
            ArchiveItem archiveView = Object.Instantiate(view.ArchiveViewPrefab, view.ArchiveScrollView.content);
            archiveView.Show(i, archives[i], SelectCallback);
        }
    }
    private void DisposeView()
    {
        view.CloseBtn.onClick.RemoveListener(CloseView);

        UIGlobalEvent.Dispatcher.Remove((byte)UIEventType.OpenArchivesView, OpenView);

        view = null;
    }

    public void Show()
    {
        view.Show();

        if (Archives.AllArchive.Count == 0)
        {

        }
    }

    public void Hide()
    {
        view.Hide();
    }



    private void OpenView(byte key)
    {
        view.gameObject.SetActive(true);
    }

    private void CloseView()
    {
        view.gameObject.SetActive(false);
    }

    private void SelectCallback(int index)
    {
        selectIndex = index;
    }
}
