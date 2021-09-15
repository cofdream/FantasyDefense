using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;
    public void SetData(Pet pet)
    {
        nameText.text = pet.PetBase.Name;
        levelText.text = "Lv: " + pet.Level.ToString();
        hpBar.SetHp((float)pet.Hp / pet.MaxHp);
    }
}
