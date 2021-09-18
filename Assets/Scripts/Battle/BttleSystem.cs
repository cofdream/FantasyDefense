using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BttleSystem : MonoBehaviour
{
    public BattleUnit playerUnit;
    public BattleUnit TargetUnit;

    public static BttleSystem I { get; private set; }

    private void Awake()
    {
        if (I == null) I = this;
    }

    public void StartBattle()
    {

    }

}