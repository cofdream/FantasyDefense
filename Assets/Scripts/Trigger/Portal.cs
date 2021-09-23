using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour, IPlayerTriggerable
{
    public LevelBase OutLevelBase;
    public Vector3 Position;

    void IPlayerTriggerable.OnPlayerTriggerable(PlayerController player)
    {
        Mask.I.Mask1();

        LevelSystem.LoadLevel(OutLevelBase.Id);
        player.transform.position = Position;
    }
}