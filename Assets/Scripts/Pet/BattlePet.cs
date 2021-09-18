using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePet : ScriptableObject
{
    [SerializeField] PetBase petBase;
    [SerializeField] int level;
}
