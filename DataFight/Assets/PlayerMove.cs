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
    }

    private void Update()
    {
        // Ugrás ellenõrzése csak akkor, ha a karakter talajon van
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // Frissítjük a talajon lévés állapotot
        }
    }

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
        // Ha a karakter nem érintkezik a talajjal, akkor nem lehet talajon
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Jumpable"))
        {
            isGrounded = false;
        }
    }
}
