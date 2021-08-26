using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIPanelBase : IUIPanel
{
    protected IView view;
    public virtual void Init(IView view)
    {
        this.view = view;
    }
    protected virtual void InitView()
    {
        
    }
    protected virtual void DisposeView()
    {
        view = null;
    }
    public virtual void Show()
    {
        view.Show();
    }
    public virtual void Hide()
    {
        view.Hide();
    }
}
