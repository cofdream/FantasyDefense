using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ViewBase : MonoBehaviour, IView
{
    public CanvasGroup CanvasGroup;

    public void Show()
    {
        CanvasGroup.alpha = 1;
    }
    public void Hide()
    {
        CanvasGroup.alpha = 0;
    }

    protected virtual void Reset()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
    }
}