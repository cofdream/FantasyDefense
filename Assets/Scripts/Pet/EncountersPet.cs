using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncountersPet : ScriptableObject
{
    [SerializeField] PetBase petBase;
    [SerializeField] int level;
    [SerializeField, Range(0, 100)] int probability;

    public int Probability => probability;

    public Pet GetPet()
    {
        return new Pet(petBase, level);
    }
}