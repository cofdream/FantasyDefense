using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTriggerable : MonoBehaviour, IPlayerTriggerable
{
    [SerializeField, Range(0, 100)] int probability;
    [SerializeField] EncountersPet[] encountersPets;

    public void OnPlayerTriggerable(PlayerController player)
    {
        if (Random.Range(0, 101) <= probability)
        {

            int index = Random.Range(0, encountersPets.Length);
            encountersPets[index].GetPet();
        }
    }
}