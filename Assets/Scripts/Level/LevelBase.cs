using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelBase : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] new string name;

    public int Id => id;
    public string Name => name;

    public void EnterLevel()
    {

    }
    public void ExitLevel()
    {

    }
}