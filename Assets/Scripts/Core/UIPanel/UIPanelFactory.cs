using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class UIPanelFactory : MonoBehaviour
{
    [Serializable]
    private struct PanelConfig
    {
        public string[] ViewPath;
    }

    private delegate IUIPanel CreatePanel();



    private static UIPanelFactory instance;



    public static IUIPanelControl GetPanel(UIPanelType type)
    {
        int index = (int)type;

        var viewPrefab = AssetDatabase.LoadAssetAtPath<ViewBase>(instance.panelConfig.ViewPath[index]);
        IView view = Instantiate(viewPrefab, instance.rootTransform);

        // ∑¥…‰
        IUIPanel panel = instance.CreatePanels[index].Invoke();
        panel.Init(view);

        return panel;
    }
    public static void GetPanelAsync(UIPanelType type, Action<IUIPanelControl> callback)
    {
        instance.StartCoroutine(GetPanelAsyncCoroutine(type, callback));
    }
    private static IEnumerator GetPanelAsyncCoroutine(UIPanelType type, Action<IUIPanelControl> callback)
    {
        int index = (int)type;

        var viewPrefab = AssetDatabase.LoadAssetAtPath<ViewBase>(instance.panelConfig.ViewPath[index]);
        IView view = Instantiate(viewPrefab, instance.rootTransform);

        yield return null;

        // ∑¥…‰
        IUIPanel panel = instance.CreatePanels[index].Invoke();
        panel.Init(view);

        yield return null;

        callback(panel);
    }

    public static void ShowPanel(UIPanelType type)
    {
        ShowPanel(GetPanel(type));
    }
    public static void ShowPanelAsync(UIPanelType type)
    {
        GetPanelAsync(type, ShowPanel);
    }
    private static void ShowPanel(IUIPanelControl panel)
    {
        panel.Show();
    }



    [SerializeField] Transform rootTransform;
    [SerializeField] PanelConfig panelConfig;
    [SerializeField] CreatePanel[] CreatePanels;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;

            CreatePanels = new CreatePanel[]
            {
                ()=>{ return null; },
                ()=>{ return new MainPanel(); }
            };

        }
    }
}
public enum UIPanelType
{
    None = 0,
    MainPanel,
    ArchivesView,
    BattleView,
}


public interface IUIPanelControl
{
    void Show();
    void Hide();
}

public interface IUIPanel : IUIPanelControl
{
    void Init(IView view);
}