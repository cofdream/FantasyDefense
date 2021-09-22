using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EncountersPetArray : ScriptableObject
{
    [Serializable]
    public struct EncountersPet
    {
        public PetBase PetBase;
        public int Level;
        [Range(0, 100)] public int Probability;
    }



    [SerializeField] EncountersPet[] encountersPets;
    public EncountersPet[] EncountersPets => encountersPets;


    public Pet GetPet()
    {
        int length = encountersPets.Length;
        if (length == 0) return null;

        int randomValue = Random.Range(1, 101);
        int value = 0;

        for (int i = 0; i < length; i++)
        {
            var item = encountersPets[i];
            value += item.Probability;
            if (value < randomValue)
            {
                continue;
            }
            else
            {
                return new Pet(item.PetBase, item.Level);
            }
        }

        var petConfig = encountersPets[length - 1];
        return new Pet(petConfig.PetBase, petConfig.Level);
    }

    private void OnValidate()
    {
        //todo ¸ÄÎªHelpBox eroor
        if (encountersPets != null)
        {
            int value = 0;
            for (int i = 0; i < encountersPets.Length; i++)
            {
                value += encountersPets[i].Probability;
                if (value > 100)
                {
                    Debug.Log($"index: {i} protbability > 100%");
                }
            }
        }
    }
}