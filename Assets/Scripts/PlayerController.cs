using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public Animator animator;

    public LayerMasks LayerMasks;

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

        //animator.SetBool("Walk", Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0);
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

            if (IsWalkable(moveTargetPosition + new Vector3(0, 0.5f, 0)))
            {
                isMoving = true;
                Moving(moveTargetPosition, MoveSpeed);
            }

            animator.SetFloat("X", x);
            animator.SetFloat("Y", 0);

            animator.SetBool("Walk", true);
        }
        else if (y != 0)
        {
            moveTargetPosition = transform.position + new Vector3(0, y, 0);

            if (IsWalkable(moveTargetPosition + new Vector3(0, 0.5f, 0)))
            {
                isMoving = true;
                Moving(moveTargetPosition, MoveSpeed);
            }

            animator.SetFloat("X", 0);
            animator.SetFloat("Y", y);

            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
    private void Moving(Vector3 targetPostion, float speed)
    {
        if ((transform.position - targetPostion).sqrMagnitude < Mathf.Epsilon)
        {
            isMoving = false;
            transform.position = targetPostion;

            animator.SetBool("Walk", false);
            MoveOver();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPostion, speed * Time.deltaTime);
        }
    }

    private bool IsWalkable(Vector3 targetPosition)
    {
        if (Physics2D.OverlapCircle(targetPosition, 0.3f, LayerMasks.SolideObjectLayerMask) != null)
        {
            return false;
        }
        return true;
    }

    private void MoveOver()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll((transform.position + new Vector3(0, 0.5f, 0)), 0.4f, LayerMasks.TriggersLayerMask);

        foreach (var collider in colliders)
        {
            var playerTriggerable = collider.GetComponent<IPlayerTriggerable>();
            if (playerTriggerable != null)
            {
                playerTriggerable.OnPlayerTriggerable(this);
            }
        }

    }
    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.3f, LayerMasks.LongGrassLayerMask))
        {
            if (Random.Range(1, 101) <= 10)
            {
                Debug.Log("Encounter something.");
            }
        }
    }


    public void Portal(int portalMapId)
    {
        Debug.Log("传送");
    }

    private void OnDrawGizmos()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (x != 0 || y != 0)
        {
            var point = moveTargetPosition + new Vector3(0, 0.5f, 0);
            float radius = 0.3f;
            if (Physics2D.OverlapCircle(point, radius, LayerMasks.SolideObjectLayerMask) != null)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }

            Gizmos.DrawSphere(point, radius);
        }
    }

}