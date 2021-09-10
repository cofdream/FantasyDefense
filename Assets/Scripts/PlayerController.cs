using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;

    private bool isMoving;
    private Vector3 moveTargetPosition;

    void Start()
    {

    }

    void Update()
    {
        if (!isMoving)
        {
            CheckMove();
        }
        else
        {
            Moving(moveTargetPosition, MoveSpeed);
        }
    }

    private void CheckMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // ∑¿÷π∂‘Ω«œﬂ“∆∂Ø
        if (x != 0)
        {
            isMoving = true;
            moveTargetPosition = transform.position + new Vector3(x, 0, 0);
            Moving(moveTargetPosition, MoveSpeed);
        }
        else if (y != 0)
        {
            isMoving = true;
            moveTargetPosition = transform.position + new Vector3(0, y, 0);
            Moving(moveTargetPosition, MoveSpeed);
        }
    }
    private void Moving(Vector3 targetPostion, float speed)
    {
        if ((transform.position - targetPostion).sqrMagnitude < Mathf.Epsilon)
        {
            isMoving = false;
            transform.position = targetPostion;
            CheckMove();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPostion, speed * Time.deltaTime);
        }
    }
}
