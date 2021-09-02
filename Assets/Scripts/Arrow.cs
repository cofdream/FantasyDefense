using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float LaunchSpeed;
    public Vector3 LaunchDirection;
    public float Damage;
    [SerializeField] float dieTime;

    void Start()
    {
        transform.eulerAngles = LaunchDirection;

        Invoke("Die", dieTime);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position += transform.right * LaunchSpeed;
    }

    void Die()
    {
        Destroy(gameObject);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
            collision.gameObject.GetComponent<Enemy>().Damage(Damage);
        }
    }
}
