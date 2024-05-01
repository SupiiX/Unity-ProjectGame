using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Weapon : MonoBehaviour
{
    public int damage = 1;
    GameObject health;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos+= transform.up * attackOffset.y;

        Collider2D collInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(collInfo != null)
        {
            //collInfo.GetComponent<PlayerHealth>().DecreaseHealth(damage);
            health.GetComponent<PlayerHealth>().DecreaseHealth(damage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player");  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
