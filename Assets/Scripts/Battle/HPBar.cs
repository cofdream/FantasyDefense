using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;
    public void SetHp(float hpNormailzed)
    {
        health.transform.localScale = new Vector3(hpNormailzed, 1f, 1f);
    }
}
