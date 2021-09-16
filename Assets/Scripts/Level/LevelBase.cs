using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBase : MonoBehaviour
{
    [SerializeField] int Id;
    [SerializeField] new string name;
    [SerializeField] GameObject levelPrefab;
    [SerializeField] PortalBase[] portalBases;


    public void EnterLevel()
    {

    }
    public void ExitLevel()
    {

    }
}

[System.Serializable]
public struct PortalBase
{
    public LevelBase enterLevelBase;
    public Vector3 enterPosition;
}