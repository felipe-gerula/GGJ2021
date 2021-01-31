using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 5f;
    public bool attack = false;
    public float attackAnimationTrigger = 0;
    public Animator anim;

    private void Start() {
        rb = this.GetComponent<Rigidbody2D>(); 
    }

    private void Update() {
        if (Vector2.Distance(transform.position, player.position) < 10)
        {
            float offset = 90f;
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        
        //direction.Normalize();
        //movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);    
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
  
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0 )
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
       PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.TakeDamage(1);
            //anim.SetFloat("attackAnimationTrigger", 1);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector3(player.position.x,player.position.y - 4f,1);
        }
    }

   public static Vector3 GetRandomDir()
   {
       return new Vector3(UnityEngine.Random.Range(-1f,1f),UnityEngine.Random.Range(-1f,1f)).normalized;
   }
}
