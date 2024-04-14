using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private Rigidbody2D rb;
    private float horizontalInput;

    //--
   
    // private Transform T;

    //
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.position += movement * Time.fixedDeltaTime;

        

        spriteRenderer.flipX = horizontalInput < 0 ? true : false;


    }

    private void Update()
    {
        // Ugr�s ellen�rz�se csak akkor, ha a karakter talajon van
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // talajon van 
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Jumpable"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // nincs a talajon
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Jumpable"))
        {
            isGrounded = false;
        }
    }


}
