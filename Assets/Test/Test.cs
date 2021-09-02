using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Test : MonoBehaviour
{
    public Image bg;
    public Text text;
    public float waitTime = 0.01f;
    private void Start()
    {
        StartCoroutine(Doit());
    }

    private IEnumerator Doit()
    {
        //for (int I = 1000; I >= 0; I += -1)
        //{
        //    bg.fillAmount = I / 1000f;
        //    //Color Cl = new Color(255 * (1 - (I / 1000f)), 255 * (I / 1000f), 0);

        //    bg.color = new Color(255f * (1000f - I) / 1000f, 255f * (I / 1000f), 0);

        //    text.text = "<color=255,200,0>HP</color> " + I;

        //    yield return new WaitForSeconds(waitTime);
        //}


        for (int i = 0; i < 255; i++)
        {
            bg.fillAmount = 1 - i / 510f;

            text.text = "<color=255,200,0>HP</color> " + (510 - i).ToString();

            bg.color = new Color(i / 255f, 1f, 0f);

            yield return new WaitForSeconds(waitTime);
        }

        for (int i = 0; i < 255; i++)
        {
            bg.fillAmount = 0.5f - i / 510f;

            text.text = "<color=255,200,0>HP</color> " + (510 - i).ToString();

            bg.color = new Color(1f, (255f - i) / 255f, 0f);

            yield return new WaitForSeconds(waitTime);
        }


        bg.fillAmount = 0;
        text.text = "<color=255,200,0>HP</color> 0";
    }
}