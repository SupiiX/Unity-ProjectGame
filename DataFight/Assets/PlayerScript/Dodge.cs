using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    // A dodging sebess�ge
    public float dodgeSpeed = 5f;

    // A dodging m�rt�ke (x tengelyen mennyit t�r�nk ki)
    public float DodgeTime = 0.5f;

    // Az utols� mozg�sir�ny
    private Vector2 lastMoveDirection = Vector2.zero;

    public bool ISdodging = false;

    // A dodge cooldown ideje
    public float dodgeCooldown = 1.5f;

    private float dodgeTimer;

    private bool FirstTime = true;

    private Rigidbody2D rb;

    private void Start()
    {
        dodgeTimer = dodgeCooldown;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Beolvastuk a joystick bevitelt
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Friss�tj�k az utols� mozg�sir�nyt
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            // lastMoveDirection = new Vector2(horizontalInput, verticalInput);
            lastMoveDirection = horizontalInput < 0 ? Vector2.left : Vector2.right;
        }
        else if (FirstTime)
        {

            lastMoveDirection = Vector2.right;
            FirstTime = false;
        }

        // Ellen�rizz�k, hogy a j�t�kos kit�r-e �s hogy letelt-e a cooldown
        if (Input.GetButtonDown("Dodge") && dodgeTimer <= 0)
        {
            // Beolvastuk a joystick bevitelt
            // Meghat�rozzuk a kit�r�s ir�ny�t
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

            // Kit�r�s v�grehajt�sa
            rb.velocity = dodgeDirection * dodgeSpeed;

            ISdodging = true;

            StartCoroutine(StopDodgeAfterTime(DodgeTime));

            // Cooldown be�ll�t�sa
            dodgeTimer = dodgeCooldown;
        }

        // Cooldown cs�kkent�se
        dodgeTimer -= Time.deltaTime;

        Debug.Log($"{dodgeTimer}");
    }

    private IEnumerator StopDodgeAfterTime(float dodgeTime)
    {
        yield return new WaitForSeconds(dodgeTime);
        rb.velocity = Vector2.zero;
        ISdodging = false;
    }
}

