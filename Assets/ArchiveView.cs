using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchiveView : MonoBehaviour
{
    public Button RemoveBtn;
    public Button SelectBtn;
    public Text InfoText;

    private int index;
    private Action<int> selectCallback;
    private void Start()
    {
        RemoveBtn.onClick.AddListener(RemoveArchive);
        SelectBtn.onClick.AddListener(SelectArchive);
    }
    private void OnDestroy()
    {
        RemoveBtn.onClick.RemoveListener(RemoveArchive);
        SelectBtn.onClick.RemoveListener(SelectArchive);
    }

    public void Show(int index, Archive archive, Action<int> selectCallback)
    {
        this.index = index;
        InfoText.text = archive.Name + " Time:" + archive.DateTime.ToString("G");
        this.selectCallback = selectCallback;
    }

    private void RemoveArchive()
    {

    }
    private void SelectArchive()
    {
        selectCallback?.Invoke(index);
    }
}
