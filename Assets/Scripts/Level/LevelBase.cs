using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelBase : ScriptableObject
{
    [SerializeField, FormerlySerializedAs("Id")] int id;
    [SerializeField] new string name;
    [SerializeField] GameObject levelPrefab;
    [SerializeField] PortalBase[] portalBases;

    public int Id => id;
    public string Name => name;
    public GameObject LevelPrefab => levelPrefab;


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
    public LevelBase LevelBase;
    public Transform Transform;
    public Vector3 Position;
}