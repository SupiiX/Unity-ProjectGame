using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    
    private SpriteRenderer spriteRenderer1;
    private SpriteRenderer spriteRenderer2;
    private SpriteRenderer spriteRenderer3;

    //private bool isFacingRight = true;

    void Start()
    {
     
        spriteRenderer1 = object1.GetComponent<SpriteRenderer>();
        spriteRenderer2 = object2.GetComponent<SpriteRenderer>();
        spriteRenderer3 = object3.GetComponent<SpriteRenderer>();
             
    }

    void Update()
    {
        // Olvassuk be a joystick irányát
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        spriteRenderer1.flipX = horizontal < 0 ? true : false;
        spriteRenderer2.flipX = horizontal < 0 ? true : false;
        spriteRenderer3.flipX = horizontal < 0 ? true : false;


        // Alapértelmezett eset, ha a joystick nem mozog
        if (horizontal == 0 && vertical == 0)
        {
            SetActiveObject(object1);
            //animator1.SetBool("PlayAnimation", true);
        }
        // Ha a joystick jobbra van mozgatva
        else if (horizontal > 0 && vertical < 0.2 || horizontal < 0 && vertical < 0.2)
        {
            SetActiveObject(object1);
            //animator1.SetBool("PlayAnimation", true);
        }
        // Ha a joystick átlósan felfelé van mozgatva
        else if (horizontal > 0.6 && vertical > 0.6 || horizontal < -0.6 && vertical > 0.6)
        {
            SetActiveObject(object2);
           // animator2.SetBool("PlayAnimation", true);
        }
        // Ha a joystick felfelé van mozgatva
        else if (vertical == 1 && horizontal < 0.4)
        {
            SetActiveObject(object3);
           // animator3.SetBool("PlayAnimation", true);
        }
    }

    // Minden más objektumot inaktívvá tesz és az adott objektumot aktívvá teszi
    void SetActiveObject(GameObject activeObject)
    {
        object1.SetActive(false);
        object2.SetActive(false);
        object3.SetActive(false);
      
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
