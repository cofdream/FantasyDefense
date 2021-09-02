using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType : byte
{
    Normal = 0,
}


public class BattleManager : MonoBehaviour
{
    [Serializable]
    private struct EnemyConfig
    {
        public Enemy[] EnemyPrefabs;
    }

    private static BattleManager instance;
    public static BattleManager Instance { get { return instance; } }



    [SerializeField] EnemyConfig enemyConfig;
    [SerializeField] Transform EnemysRoot;

    private void Awake()
    {
        if (instance == null) instance = this;
    }


    private void OnEnable()
    {
    }
    void Start()
    {

    }
    private void OnDisable()
    {

    }


    void Update()
    {

    }

    public void StartBattle()
    {
        var enemyPrefab = enemyConfig.EnemyPrefabs[0];
        var enemy = Instantiate(enemyPrefab, EnemysRoot.transform.position, Quaternion.identity);
        enemy.DieCallback = EnemyDie;
    }

    private void EnemyDie(Enemy enemy)
    {

    }

}
