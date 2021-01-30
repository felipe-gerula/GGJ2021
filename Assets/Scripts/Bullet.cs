using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public GameObject hitEffect;
    public Rigidbody2D rb;

    void Start() {
        rb.velocity = transform.right * speed;
    }

   void OnCollisionEnter2D(Collision2D collision)
   {
       //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
       //Destroy(effect,1f);
       Destroy(gameObject);
   }

    void OnTriggerEnter2D(Collider2D other) {
       Enemy enemy = other.GetComponent<Enemy>();
       if (enemy != null)
       {
           enemy.TakeDamage(30);
       }
       Destroy(gameObject);
   }


}
