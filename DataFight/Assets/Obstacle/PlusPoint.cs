using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusPoint : MonoBehaviour
{
    public int health = 100;
    private int currentHealth; // Jelenlegi �leter�

    public GameObject PuffAnimation;

    private Animator PuffAnimator;
    private bool isDestroyed = false;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;

        PuffAnimator = PuffAnimation.GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        // Debug.Log("demage");

        currentHealth -= damage; // �leter� cs�kkent�se a kapott sebz�s �rt�k�vel

        // Ha az �leter� el�ri vagy meghaladja a 0-t, akkor az akad�lyt megsemmis�tj�k
        if (currentHealth <= 0)
        {
            if (!isDestroyed)
            {
                StartCoroutine(DestroyObstacleWithDelay());
            }
        }
    }

    IEnumerator DestroyObstacleWithDelay()
    {
        isDestroyed = true;
        yield return new WaitForSeconds(0.35f);
        Destroy(gameObject);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDestroyed)
        {
            return; // Ha m�r megsemmis�lt az akad�ly, ne t�rt�njen semmi
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            if (!isDestroyed)
            {
                StartCoroutine(DestroyObstacleWithDelay());
            }
        }
        else if (other.CompareTag("Player"))
        {
            //J�t�koshoz val� �tk�z�s eset�n

            PlayerMove playerMove = other.GetComponent<PlayerMove>();

          
            if (!isDestroyed)
            {
                StartCoroutine(DestroyObstacleWithDelay(playerMove));
            }

           // GroundTrigger.SetActive(false);


        }

        PuffAnimator.SetBool("DashDust", true);


        StartCoroutine(ResetJumpDustTrigger()); 


       // StartCoroutine(ResetGroundTrigger());
    }


    IEnumerator DestroyObstacleWithDelay(PlayerMove playerMove)
    {
        isDestroyed = true;
        yield return new WaitForSeconds(0.35f);
        Destroy(gameObject);

        if (playerMove != null)
        {
            playerMove.isGrounded = true;
        }

    }



    IEnumerator ResetJumpDustTrigger()
    {
        yield return new WaitForSeconds(0.35f);
        PuffAnimator.SetBool("DashDust", false);
    }
}
