using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchivesView : MonoBehaviour
{
    [SerializeField] Button CloseBtn;
    [SerializeField] ScrollRect ArchiveScrollView;
    [SerializeField] ArchiveView ArchiveViewPrefab;
    private int selectIndex;
    void Start()
    {
        CloseBtn.onClick.AddListener(CloseView);

        UIGlobalEvent.Dispatcher.Add((byte)UIEventType.OpenArchivesView, OpenView);

        var archives = Archives.AllArchive;
        int length = archives.Count;
        for (int i = 0; i < length; i++)
        {
            ArchiveView archiveView = Instantiate(ArchiveViewPrefab, ArchiveScrollView.content);
            archiveView.Show(i, archives[i], SelectCallback);
        }
    }

    private void OnDestroy()
    {
        CloseBtn.onClick.RemoveListener(CloseView);

        UIGlobalEvent.Dispatcher.Remove((byte)UIEventType.OpenArchivesView, OpenView);
    }


    private void OpenView(byte key)
    {
        gameObject.SetActive(true);
    }

    private void CloseView()
    {
        gameObject.SetActive(false);
    }

    private void SelectCallback(int index)
    {
        selectIndex = index;
    }
}