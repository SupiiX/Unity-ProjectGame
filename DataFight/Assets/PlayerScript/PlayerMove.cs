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

    private bool isDodging;
    private bool FaceChanged;

    public GameObject DustRight;
    private Animator animatorRight;

    public GameObject DustLeft;
    private Animator animatorLeft;



    private bool AfterJump = false;


    private Vector2 lastMoveDirection;

    private bool FirstTime;


    void Start()
    {
        isDodging = GetComponent<Dodge>().ISdodging;

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        animatorRight = DustRight.GetComponent<Animator>();

        animatorLeft = DustLeft.GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        if (!isDodging) { 
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

    }

    void Update()
    {

        if (horizontalInput != 0f )
        {
            // lastMoveDirection = new Vector2(horizontalInput, verticalInput);
            lastMoveDirection = horizontalInput < 0 ? Vector2.left : Vector2.right;
        }
        else if (FirstTime)
        {

            lastMoveDirection = Vector2.right;
            FirstTime = false;
        }


        // Ugr�s ellen�rz�se csak akkor, ha a karakter talajon van
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // 
            AfterJump = true;
        }

        if (isGrounded && AfterJump)
        {


            if (lastMoveDirection == Vector2.left)
            {

                animatorLeft.SetBool("JumpDust", true);
                StartCoroutine(ResetJumpDustTrigger(animatorLeft));
                
                // Debug.Log("xx--");

            }
            else
            {
                animatorRight.SetBool("JumpDust", true);
                StartCoroutine(ResetJumpDustTrigger(animatorRight));
               

            }
            AfterJump = false;
        }


        //if (Input.GetKeyDown(KeyCode.P)){

        // GetComponent<PauseMenu>().Pause();

        //}      
    }

    IEnumerator ResetJumpDustTrigger(Animator Animation)
    {
        yield return new WaitForSeconds(0.5f);
        Animation.SetBool("JumpDust", false);
    }

    //IEnumerator ResetJumpDustTrigger()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    animatorRight.SetBool("JumpDust", false);
    //}

    //IEnumerator ResetDashDustTrigger(Animator Animation)
    //{
    //    yield return new WaitForSeconds(0.35f);
    //    Animation.SetBool("DashDust", false);
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
