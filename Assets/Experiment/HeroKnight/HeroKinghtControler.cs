using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroKinghtControler : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;

    public float JumpSpeed = 0.3f;

    public float TimeScale = 1;

    private float horizontal;

    private bool isJump = false;
    private bool isFall = false;
    void Start()
    {

    }

    void Update()
    {
        Time.timeScale = TimeScale;

        if (isJump)
        {
            transform.position += new Vector3(0, JumpSpeed * Time.deltaTime, 0);
        }
        if (isFall)
        {
            transform.position -= new Vector3(0, JumpSpeed * Time.deltaTime, 0);
            if (transform.position.y <= 0)
            {
                transform.position = new Vector3(transform.position.x, 0, 0);

                isFall = false;
                animator.SetTrigger("EndFall");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            isJump = true;
            animator.SetTrigger("Jump");
            Invoke("StartFall", 0.5f);
        }

        var h = Input.GetAxis("Horizontal");
        if (h != 0)
        {
            spriteRenderer.flipX = h < 0;
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }


    }
    private void StartFall()
    {
        isJump = false;
        isFall = true;
        animator.SetTrigger("Fall");
    }

    private void OnValidate()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
}
