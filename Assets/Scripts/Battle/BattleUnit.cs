using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] PetBase petBase;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;
    public Pet Pet { get; set; }

    public void Setup()
    {
        Pet = new Pet(petBase, level);
        GetComponent<Image>().sprite = isPlayerUnit ? Pet.PetBase.BackSprite : Pet.PetBase.FrontSprite;
    }
}
