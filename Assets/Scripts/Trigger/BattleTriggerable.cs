using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTriggerable : MonoBehaviour, IPlayerTriggerable
{
    [SerializeField, Range(0, 100)] uint probability;
    [SerializeField] EncountersPetArray encountersPet;

    public void OnPlayerTriggerable(PlayerController player)
    {

    //    tilemap.SetTile(tilemap.WorldToCell(player.transform.position), null);

        if (Random.Range(1, 101) <= probability)
        {
            encountersPet.GetPet();
            Debug.Log(1);
        }
    }
}