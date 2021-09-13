using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public Animator animator;
    public LayerMask SolideObjectLayerMask;
    public LayerMask LongGrassLayerMask;


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

        animator.SetBool("Walk", Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0);
    }



    private void CheckMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // 防止对角线移动
        if (x != 0)
        {
            // todo
            // 旋转面向
            // 移动
            moveTargetPosition = transform.position + new Vector3(x, 0, 0);

            if (IsWalkable(moveTargetPosition))
            {
                isMoving = true;
                Moving(moveTargetPosition, MoveSpeed);
            }

            animator.SetFloat("X", x);
            animator.SetFloat("Y", 0);
        }
        else if (y != 0)
        {
            moveTargetPosition = transform.position + new Vector3(0, y, 0);

            if (IsWalkable(moveTargetPosition))
            {
                isMoving = true;
                Moving(moveTargetPosition, MoveSpeed);
            }

            animator.SetFloat("X", 0);
            animator.SetFloat("Y", y);
        }
    }
    private void Moving(Vector3 targetPostion, float speed)
    {
        if ((transform.position - targetPostion).sqrMagnitude < Mathf.Epsilon)
        {
            isMoving = false;
            transform.position = targetPostion;

            CheckForEncounters();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPostion, speed * Time.deltaTime);
        }
    }

    private bool IsWalkable(Vector3 targetPosition)
    {
        if (Physics2D.OverlapCircle(targetPosition, 0.2f, SolideObjectLayerMask) != null)
        {
            return false;
        }
        return true;
    }

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.3f, LongGrassLayerMask))
        {
            if (Random.Range(1, 101) <= 10)
            {
                Debug.Log("Encounter something.");
            }
        }
    }

    private void OnDrawGizmos()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (x != 0 || y != 0)
        {
            if (Physics2D.OverlapCircle(moveTargetPosition, 0.2f, SolideObjectLayerMask) != null)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }

            Gizmos.DrawSphere(moveTargetPosition, 0.2f);
        }
    }
}