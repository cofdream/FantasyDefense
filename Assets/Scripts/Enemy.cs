using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody2D;
    [SerializeField] float speed;
    [SerializeField] float offsetX = -0.8f;
    [SerializeField] float attackRange = 0.1f;
    [SerializeField] LayerMask layerMask;

    public float Hp;
    public UnityAction<Enemy> DieCallback;

    void Start()
    {
       
    }

    void FixedUpdate()
    {
        var collider2D = Physics2D.OverlapCircle(transform.position + new Vector3(offsetX, 0f, 0f), attackRange, layerMask);
        if (collider2D == null)
        {
            rigidbody2D.velocity = -transform.right * speed;
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
        }
       
    }

    public void Damage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            DieCallback(this);
            Destroy(gameObject);
        }
        else
        {

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + new Vector3(offsetX, 0f, 0f), attackRange);
    }
}
