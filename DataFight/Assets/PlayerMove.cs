using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    //public Transform groundCheck;
    //public LayerMask groundLayer;

    //private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private Rigidbody2D rb;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // Karakter mozgatása
        horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        // rb.velocity = movement;
        rb.position += movement * Time.fixedDeltaTime;

        // AnimationUpdate();

    }
    private void Update()
    {

        // Ugrás ellenõrzése
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            //anim.SetBool();
        }

        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //void AnimationUpdate()
    //{

    //    if (horizontalInput > 0f)
    //    {
    //        anim.SetBool("Running", true);
    //        spriteRenderer.flipX = false;

    //    }
    //    else if (horizontalInput < 0f)
    //    {
    //        anim.SetBool("Running", true);
    //        spriteRenderer.flipX = true;
    //    }
    //    else
    //    {
    //        anim.SetBool("Running", false);
    //    }

    //}


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ellenõrizzük, hogy a karakter a talajon vagy egy ugratható objektumon van-e
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Jumpable"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // A karakter nincs a talajon vagy egy ugratható objektumon
        //if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Jumpable"))
        //{
        //    isGrounded = false;
        //}

        if (collision.contacts.Any(contact => contact.normal.y > 0.5))
        {
            isGrounded = false;
        }
    }


}
