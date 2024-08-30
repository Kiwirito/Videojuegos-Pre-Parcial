using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float runSpeed = 3f;  // Velocidad de movimiento
    public float jumpForce = 6f;  // Fuerza del salto
   
    private Rigidbody2D rb;

    public bool betterJump = false;

    public float fallMultiplayer = 0.5f;

    public float lowJumpMultipalyer = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Obtenemos el Rigidbody2D
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);

        } else {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Run", false);
        }
        if (Input.GetKey("space") && GrounCheck.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (GrounCheck.isGrounded==false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (GrounCheck.isGrounded==true)
        {
            animator.SetBool("Jump", false);

        }

    }


}
