using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] new Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.velocity = transform.forward * 30;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
