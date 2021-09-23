using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BttleSystem : MonoBehaviour
{
    public CanvasGroup battleCanvasGroup;

    public BattleUnit playerUnit;
    public BattleUnit TargetUnit;

    //public BattleUnit[] BattleUnits;
    //public BattlePlayer[] BattlePlayers;

    public static BttleSystem I { get; private set; }

    private void Awake()
    {
        if (I == null) I = this;

        battleCanvasGroup.alpha = 0;
    }

    public void StartBattle()
    {

    }
}