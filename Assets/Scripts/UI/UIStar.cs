using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStar : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] Button btnStart;
    [SerializeField] Button btnContuin;
    [SerializeField] Button btnOptions;
    [SerializeField] Button btnQuit;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError(this.name);
        }

        btnStart.onClick.AddListener(default);
        btnContuin.onClick.AddListener(default);
        btnOptions.onClick.AddListener(default);
        btnQuit.onClick.AddListener(default);
    }

    private void OnDestroy()
    {
        btnStart.onClick.RemoveListener(default);
        btnContuin.onClick.RemoveListener(default);
        btnOptions.onClick.RemoveListener(default);
        btnQuit.onClick.RemoveListener(default);
    }

    private static UIStar instance;
}
