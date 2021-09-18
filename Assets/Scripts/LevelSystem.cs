using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    static LevelSystem i;
    public static int CurrentLevelId { get; private set; }


    public LevelBase[] LevelBases;

    private GameObject currentLevel;


    private void Awake()
    {
        if (i == null) i = this;
    }

    public static void LoadLevel(int levelId)
    {
        foreach (var LevelBase in i.LevelBases)
        {
            if (LevelBase.Id == levelId)
            {
                if (i.currentLevel != null)
                {
                    Destroy(i.currentLevel);
                }

                i.currentLevel = GameObject.Instantiate(LevelBase.LevelPrefab);
                CurrentLevelId = levelId;
            }
        }
    }
}
