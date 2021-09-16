using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mask : MonoBehaviour
{
    [SerializeField] Image mask;

    [SerializeField] bool isPlay;

    public static Mask I;
    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }
        isPlay = false;
    }
    public void Mask1()
    {
        if (!isPlay)
        {
            StartCoroutine(Mask1_Coroutine());
        }
    }

    IEnumerator Mask1_Coroutine()
    {
        isPlay = true;
        var color = Color.black;
        float a = 255;
        while (true)
        {
            a -= 1;
            color.a = a / 255f;
            mask.color = color;

            if (a == 0)
            {
                isPlay = false;
                break;
            }
            yield return null;
        }
    }
}
