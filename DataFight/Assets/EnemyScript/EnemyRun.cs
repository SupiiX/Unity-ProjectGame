using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyRun : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    private bool isDead = false; // �j v�ltoz� az enemy �let�llapot�nak nyomon k�vet�s�re



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointA.transform;

        

    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Health health = GetComponent<Enemy_Health>();

        if (health != null)
        {
            isDead = health.isDead;

        }
        
        // Csak mozg�s, ha az enemy nem halott
        if (!isDead)
        {
            Vector2 point = currentPoint.position - transform.position;
            if (currentPoint == pointA.transform)
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(speed, 0);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform)
            {
                // anim.SetTrigger("Turn");
                // yield return new WaitForSeconds(1);

                flip();
                currentPoint = pointA.transform;
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)
            {
                // anim.SetTrigger("Turn");
                // yield return new WaitForSeconds(1);

                flip();
                currentPoint = pointB.transform;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;

        }
    }

    public void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    
    //// A bullet �tk�z�s�nek kezel�se
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Bullet"))
    //    {
    //        // Ha az enemyhez �tk�zik a bullet, meg�ll�tjuk az enemy mozg�s�t
    //        rb.velocity = Vector2.zero;
    //        isDead = true; // Az enemy mostant�l halott
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 1f);
        Gizmos.DrawWireSphere(pointB.transform.position, 1f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
