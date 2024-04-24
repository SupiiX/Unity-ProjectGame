using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    // A dodging sebessége
    public float dodgeSpeed = 5f;

    // A dodging mértéke (x tengelyen mennyit térünk ki)
    public float dodgeDistance = 0.5f;

    // Az utolsó mozgásirány
    private Vector2 lastMoveDirection = Vector2.zero;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Beolvastuk a joystick bevitelt
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Frissítjük az utolsó mozgásirányt
        if (horizontalInput != 0f || verticalInput != 0f)
        {
          //  lastMoveDirection = new Vector2(horizontalInput, verticalInput);

            lastMoveDirection = horizontalInput < 0 ? Vector2.left: Vector2.right;

        }
    }

    private void FixedUpdate()
    {
        // Ellenõrizzük, hogy a játékos kitér-e
        if (Input.GetButtonDown("Dodge"))
        {
            // Beolvastuk a joystick bevitelt
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            // Meghatározzuk a kitérés irányát
            Vector2 dodgeDirection;

            if (horizontalInput > 0)
            {
                dodgeDirection = Vector2.right;
            }
            else if (horizontalInput < 0)
            {
                dodgeDirection = Vector2.left;
            }
            else
            {
                dodgeDirection = lastMoveDirection;
            }
           

            // Kitérés végrehajtása
            rb.velocity = dodgeDirection * dodgeSpeed;

            StartCoroutine(StopDodgeAfterTime(0.2f));
        }
    }

    private IEnumerator StopDodgeAfterTime(float dodgeTime)
    {
        yield return new WaitForSeconds(dodgeTime);
        rb.velocity = Vector2.zero;
    }
}

