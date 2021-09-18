using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIPanel : IUIPanelControl
{
    void Init(IView view);
}