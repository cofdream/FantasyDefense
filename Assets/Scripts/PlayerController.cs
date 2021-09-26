using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public Animator animator;
    public LayerMasks LayerMasks;

    private PlayerArchive playerArchive;

    private Vector2 movement;
    private float MoveX;
    private float MoveY;

    private void Start()
    {
        //读取存档
        //创建角色
        //打开存档时所在的地图，设置坐标为存档时的坐标
        //加载当前任务

        playerArchive = PlayerArchive.Load("Player");

        LevelSystem.LoadLevel(playerArchive.LevelId);
        transform.position = playerArchive.Position;
        animator.SetFloat("X", playerArchive.X);
        animator.SetFloat("Y", playerArchive.Y);


        moveTargetPosition.x = playerArchive.X;
        moveTargetPosition.y = playerArchive.Y;


        isMoving = false;
    }

    private void OnDestroy()
    {
        //Todo放到Save
        playerArchive.LevelId = LevelSystem.CurrentLevelId;
        playerArchive.Position = transform.position;
        playerArchive.X = MoveX;
        playerArchive.Y = MoveY;

        PlayerArchive.Save(playerArchive, "Player");
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (movement == Vector2.zero)
        {
            animator.SetBool("Walk", false);
        }
        else
        {
            MoveX = movement.x;
            MoveY = movement.y;

            animator.SetFloat("X", MoveX);
            animator.SetFloat("Y", MoveY);

            animator.SetBool("Walk", true);

            transform.position += new Vector3(MoveX, MoveY, 0) * MoveSpeed * Time.deltaTime;
        }
    }


    //private void CheckMove(Vector2 movement)
    //{
    //    float x = movement.x;
    //    float y = movement.y;

    //    // 防止对角线移动
    //    if (x != 0)
    //    {
    //        y = 0;

    //        if (moveTargetPosition.normalized.x == x)
    //        {
    //            moveTargetPosition = transform.position + new Vector3(x, 0, 0);

    //            if (IsWalkable(moveTargetPosition))
    //            {
    //                isMoving = true;
    //                Moving(moveTargetPosition, MoveSpeed);
    //            }
    //        }
    //        else
    //        {
    //            moveTargetPosition.x *= x;
    //            animator.SetFloat("X", x);
    //            animator.SetFloat("Y", 0);
    //        }


    //        // todo
    //        // 旋转面向
    //        // 移动

    //        animator.SetBool("Walk", true);
    //    }
    //    else if (y != 0)
    //    {
    //        moveTargetPosition = transform.position + new Vector3(0, y, 0);

    //        if (IsWalkable(moveTargetPosition))
    //        {
    //            isMoving = true;
    //            Moving(moveTargetPosition, MoveSpeed);
    //        }

    //        animator.SetFloat("X", 0);
    //        animator.SetFloat("Y", y);

    //        animator.SetBool("Walk", true);
    //    }
    //    else
    //    {
    //        animator.SetBool("Walk", false);
    //    }
    //}
    //private void Moving(Vector3 targetPostion, float speed)
    //{
    //    if ((transform.position - targetPostion).sqrMagnitude < Mathf.Epsilon)
    //    {
    //        isMoving = false;
    //        transform.position = targetPostion;

    //        animator.SetBool("Walk", false);
    //        MoveOver();
    //    }
    //    else
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, targetPostion, speed * Time.deltaTime);
    //    }
    //}

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
        Collider2D[] colliders = Physics2D.OverlapCircleAll((transform.position), 0.4f, LayerMasks.TriggersLayerMask);

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

    public void OnMove(UnityEngine.InputSystem.InputValue context)
    {
        movement = context.Get<Vector2>();
    }


    private void OnDrawGizmos()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (x != 0 || y != 0)
        {
            var point = moveTargetPosition;
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