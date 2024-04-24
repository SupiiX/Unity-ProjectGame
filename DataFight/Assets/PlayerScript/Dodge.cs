using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    // A dodging sebessége
    public float dodgeSpeed = 5f;

    // A dodging mértéke (x tengelyen mennyit térünk ki)
    public float DodgeTime = 0.5f;

    // Az utolsó mozgásirány
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

        // Frissítjük az utolsó mozgásirányt
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

        // Ellenõrizzük, hogy a játékos kitér-e és hogy letelt-e a cooldown
        if (Input.GetButtonDown("Dodge") && dodgeTimer <= 0)
        {
            // Beolvastuk a joystick bevitelt
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

            ISdodging = true;

            StartCoroutine(StopDodgeAfterTime(DodgeTime));

            // Cooldown beállítása
            dodgeTimer = dodgeCooldown;
        }

        // Cooldown csökkentése
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

