using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingMoving : MonoBehaviour
{
    public float speed = 5f; // Mozg�s sebess�ge

    private int direction; // Mozg�s ir�nya: -1 balra, 1 jobbra

    //private SpriteRenderer sprite;

    //private Collider2D Coll;

    private Animator animator;

    public GameObject puffanimation;

    public bool Dead = false;

    private Rigidbody2D rb;

    void Start()
    {
        // V�letlenszer�en v�lasztunk ir�nyt
       // direction = Random.Range(0, 2) == 0 ? -1 : 1;

        rb = GetComponent<Rigidbody2D>();

        animator = puffanimation.GetComponent<Animator>();

        // Ha a j�t�kobjektum bal oldalon spawnolt, akkor jobbra megy
        if (transform.position.x < 0)
        {
            direction = 1;
        }
        // Ha a j�t�kobjektum jobb oldalon spawnolt, akkor balra megy
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
            // Mozg�s az adott ir�nyba
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

        // Kikapcsoljuk az enemy sprite-j�t
        GetComponent<SpriteRenderer>().enabled = false;

        // obstacleCollider.enabled = false;

        //foreach (Collider2D col in Coll)
        //{
        //    col.enabled = false;
        //}

        GetComponent<Collider2D>().enabled = false;


        //  rb.velocity = Vector2.zero;

        animator.SetBool("PuffDust", true);

        // Lej�tszuk a puffDust anim�ci�t
        // puffAnimator.SetBool("PuffDust", true);


        // V�runk egy kicsit, hogy lej�tssza az anim�ci�t
        StartCoroutine(DestroyAfterAnimation());
    }


    IEnumerator DestroyAfterAnimation()
    {      

        // V�runk, am�g lej�tsz�dik a puffDust anim�ci�
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("PuffDust", false);

        // Megsemmis�tj�k az enemyt
        Destroy(gameObject);
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(13);
        Destroy(gameObject);
    }


}
