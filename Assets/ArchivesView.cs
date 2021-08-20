using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchivesView : MonoBehaviour
{
    public Button CloseBtn;


    void Start()
    {
        CloseBtn.onClick.AddListener(CloseView);

        UIEventDisatcher.Dispatcher.Add((byte)UIEventType.OpenArchivesView,OpenView);
    }
   
    private void OnDestroy()
    {
        CloseBtn.onClick.RemoveListener(CloseView);

        UIEventDisatcher.Dispatcher.Remove((byte)UIEventType.OpenArchivesView, OpenView);
    }

    private void OpenView(byte key)
    {
        gameObject.SetActive(true);
    }

    private void CloseView()
    {
        gameObject.SetActive(false);
    }
}