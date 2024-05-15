using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingMoving : MonoBehaviour
{
    public float speed = 5f; // Mozgás sebessége

    private int direction; // Mozgás iránya: -1 balra, 1 jobbra

    //private SpriteRenderer sprite;

    //private Collider2D Coll;

    private Animator animator;

    public GameObject puffanimation;

    public bool Dead = false;

    private Rigidbody2D rb;

    void Start()
    {
        // Véletlenszerûen választunk irányt
       // direction = Random.Range(0, 2) == 0 ? -1 : 1;

        rb = GetComponent<Rigidbody2D>();

        animator = puffanimation.GetComponent<Animator>();

        // Ha a játékobjektum bal oldalon spawnolt, akkor jobbra megy
        if (transform.position.x < 0)
        {
            direction = 1;
        }
        // Ha a játékobjektum jobb oldalon spawnolt, akkor balra megy
        else
        {
            direction = -1;

            GetComponent<SpriteRenderer>().flipX = true;
                    

        }

        StartCoroutine(DestroyObj());
    
    }

    void Update()
    {
        if (!Dead)
        {
            // Mozgás az adott irányba
            transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        //  PlayerMove playerMove = other.GetComponent<PlayerMove>();

        //  ResetPlayer(playerMove);

        if (other.CompareTag("Player"))
        {

            other.gameObject.GetComponent<PlayerHealth>().DecreaseHealth(1);
            

            Dead = true;

            Die();
        }
    }

    public void Die()
    {

        // Kikapcsoljuk az enemy sprite-ját
        GetComponent<SpriteRenderer>().enabled = false;

        // obstacleCollider.enabled = false;

        //foreach (Collider2D col in Coll)
        //{
        //    col.enabled = false;
        //}

        GetComponent<Collider2D>().enabled = false;


        //  rb.velocity = Vector2.zero;

        animator.SetBool("PuffDust", true);

        // Lejátszuk a puffDust animációt
        // puffAnimator.SetBool("PuffDust", true);


        // Várunk egy kicsit, hogy lejátssza az animációt
        StartCoroutine(DestroyAfterAnimation());
    }


    IEnumerator DestroyAfterAnimation()
    {      

        // Várunk, amíg lejátszódik a puffDust animáció
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("PuffDust", false);

        // Megsemmisítjük az enemyt
        Destroy(gameObject);
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(13);
        Destroy(gameObject);
    }


}
