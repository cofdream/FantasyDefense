using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    [SerializeField] Transform createPoint;
    [SerializeField] Arrow arrowPrefab;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var arrow = Instantiate<Arrow>(arrowPrefab,createPoint.transform.position,Quaternion.identity);

        }
    }
}
