using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject Hand1;
    public GameObject Hand2;
    public GameObject Hand3;
    public GameObject LeftHand1;
    public GameObject LeftHand2;
    public GameObject LeftHand3;

    private SpriteRenderer spriteRenderer1;
    private SpriteRenderer spriteRenderer2;
    private SpriteRenderer spriteRenderer3;
    private SpriteRenderer spriteRenderer4;
    private SpriteRenderer spriteRenderer5;
    private SpriteRenderer spriteRenderer6;

     //private bool isFacingRight = true;

    void Start()
    {
     
        spriteRenderer1 = Hand1.GetComponent<SpriteRenderer>();
        spriteRenderer2 = Hand2.GetComponent<SpriteRenderer>();
        spriteRenderer3 = Hand3.GetComponent<SpriteRenderer>();
        spriteRenderer4 = LeftHand1.GetComponent<SpriteRenderer>();
        spriteRenderer5 = LeftHand2.GetComponent<SpriteRenderer>();
        spriteRenderer6 = LeftHand3.GetComponent<SpriteRenderer>();
                     
    }

    void Update()
    {
        // Olvassuk be a joystick irányát
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //spriteRenderer1.flipX = horizontal < 0 ? true : false;
        //spriteRenderer2.flipX = horizontal < 0 ? true : false;
        //spriteRenderer3.flipX = horizontal < 0 ? true : false;
        //spriteRenderer4.flipX= horizontal < 0 ? true : false;
        //spriteRenderer5.flipX = horizontal < 0 ? true : false;
        //spriteRenderer6.flipX = horizontal < 0 ? true : false;


        // Alapértelmezett eset, ha a joystick nem mozog
        if (horizontal == 0 && vertical == 0)
        {
            SetActiveObject(Hand1);
            //animator1.SetBool("PlayAnimation", true);
        }
        // Ha a joystick jobbra van mozgatva
        else if (horizontal > 0 && vertical < 0.2)
        {
            if (horizontal < 0 && vertical < 0.2)
            {
                SetActiveObject(LeftHand1);
            }
            else
            {
                SetActiveObject(Hand1);
            }

            //animator1.SetBool("PlayAnimation", true);
        }
        // Ha a joystick átlósan felfelé van mozgatva
        else if (horizontal > 0.6 && vertical > 0.6)
        {
            if (horizontal < -0.6 && vertical > 0.6)
            {
                SetActiveObject(LeftHand2);

            }
            else
            {
                SetActiveObject(Hand2);

            }
                       
           // animator2.SetBool("PlayAnimation", true);
        }
        // Ha a joystick felfelé van mozgatva
        else if (vertical == 1 && horizontal < 0.4)
        {
            if (vertical == 1 && horizontal < 0.4 )
            {

            }

            SetActiveObject(Hand3);
           // animator3.SetBool("PlayAnimation", true);
        }
    }

    // Minden más objektumot inaktívvá tesz és az adott objektumot aktívvá teszi
    void SetActiveObject(GameObject activeObject)
    {
        Hand1.SetActive(false);
        Hand2.SetActive(false);
        Hand3.SetActive(false);
        LeftHand1.SetActive(false);
        LeftHand2.SetActive(false);
        LeftHand3.SetActive(false);
      
        activeObject.SetActive(true);
              
    }


    //void Flip(float horizontalInput)
    //{
    //    // Karakter forgatása az irány függvényében
    //    if (horizontalInput > 0 && !isFacingRight || horizontalInput < 0 && isFacingRight)
    //    {
    //        isFacingRight = !isFacingRight;
    //        transform.Rotate(0f, 180f, 0f);
    //    }
    //}


}
