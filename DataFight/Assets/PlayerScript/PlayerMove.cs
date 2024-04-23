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


    private bool FaceChanged;

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


        if (horizontalInput < 0) // Balra mozgás esetén
        {
            spriteRenderer.flipX = true; // Tükrözve
            FaceChanged = true;
        }
        else if (horizontalInput > 0) // Jobbra mozgás esetén
        {
            spriteRenderer.flipX = false; // Normál
            FaceChanged = false;
        }
        // Ha a karakter nem mozog, de az előző mozgás irányában volt az arc
        else if (FaceChanged == true)
        {
            spriteRenderer.flipX = true; // Tükrözve marad
        }


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


    //void Jump()
    //{

    //    if (PlayerPosition.position.y == playerXJump)
    //    {
    //        isGrounded = true;

    //        Debug.Log($"{PlayerPosition.position.y}");
    //    }
    //    else
    //    {
    //        isGrounded = false;

    //        Debug.Log($"nem ugorhatsz {PlayerPosition.position.y}");

    //    }

    //}



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
