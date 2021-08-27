using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePanel : IUIPanel
{
    public BattleView view;

    public void Init(IView view)
    {
        this.view = view as BattleView;
    }

    public void Show()
    {

    }
    public void Hide()
    {

    }

}