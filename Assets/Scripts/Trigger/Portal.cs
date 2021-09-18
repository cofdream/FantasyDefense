using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour, IPlayerTriggerable
{
    public GameObject CurMap;
    public LevelBase OutLevelBase;
    void IPlayerTriggerable.OnPlayerTriggerable(PlayerController player)
    {
        Mask.I.Mask1();
   

        player.Portal(1);
    }
}