﻿using System.Collections;
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

    private void Start() {
        rb = this.GetComponent<Rigidbody2D>(); 
    }

    private void Update() {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
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
       } 
       if (other.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector3(player.position.x,player.position.y - 4f,player.position.z);
        }
    }

   public static Vector3 GetRandomDir()
   {
       return new Vector3(UnityEngine.Random.Range(-1f,1f),UnityEngine.Random.Range(-1f,1f)).normalized;
   }
}
