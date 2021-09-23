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

    private bool isMoving;
    private Vector3 moveTargetPosition;

    private PlayerArchive playerArchive;
    private Vector2 currentTowards;

    private void Start()
    {
        //��ȡ�浵
        //������ɫ
        //�򿪴浵ʱ���ڵĵ�ͼ����������Ϊ�浵ʱ������
        //���ص�ǰ����

        playerArchive = PlayerArchive.Load("Player");

        LevelSystem.LoadLevel(playerArchive.LevelId);
        transform.position = playerArchive.Position;
        animator.SetFloat("X", playerArchive.X);
        animator.SetFloat("Y", playerArchive.Y);


        moveTargetPosition.x = playerArchive.X;
        moveTargetPosition.y = playerArchive.Y;
    }

    private void OnDestroy()
    {
        //Todo�ŵ�Save
        playerArchive.LevelId = LevelSystem.CurrentLevelId;
        playerArchive.Position = transform.position;
        playerArchive.X = animator.GetFloat("X");
        playerArchive.Y = animator.GetFloat("Y");

        PlayerArchive.Save(playerArchive, "Player");
    }

    private Vector2 movement;

    void Update()
    {
        if (!isMoving)
        {
            CheckMove(movement);
        }
        else

        {
            Moving(moveTargetPosition, MoveSpeed);
        }
    }

    private void CheckMove(Vector2 movement)
    {
        float x = movement.x;
        float y = movement.y;

        // ��ֹ�Խ����ƶ�
        if (x != 0)
        {
            y = 0;

            if (moveTargetPosition.normalized.x == x)
            {
                moveTargetPosition = transform.position + new Vector3(x, 0, 0);

                if (IsWalkable(moveTargetPosition))
                {
                    isMoving = true;
                    Moving(moveTargetPosition, MoveSpeed);
                }
            }
            else
            {
                moveTargetPosition.x *= x;
                animator.SetFloat("X", x);
                animator.SetFloat("Y", 0);
            }


            // todo
            // ��ת����
            // �ƶ�

            animator.SetBool("Walk", true);
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
        Debug.Log("����");
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