using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    public Button StartBtn;
    public Button InfoBtn;
    public Button QuitBtn;

    void Start()
    {
        StartBtn.onClick.AddListener(DisableView);
        QuitBtn.onClick.AddListener(OnQuiteBtn);
        UIEventDisatcher.Dispatcher.Add((byte)UIEventType.OpenMainView, OpenView);
    }

    private void OnDestroy()
    {
        StartBtn.onClick.RemoveListener(DisableView);
        QuitBtn.onClick.RemoveListener(OnQuiteBtn);
        UIEventDisatcher.Dispatcher.Remove((byte)UIEventType.OpenMainView, OpenView);
    }

    void OpenView(byte type)
    {
        gameObject.SetActive(true);
    }
    void DisableView()
    {
        gameObject.SetActive(false);
        UIEventDisatcher.Dispatcher.Invoke((byte)UIEventType.OpenArchivesView);
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
