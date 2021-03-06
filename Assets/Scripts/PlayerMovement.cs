﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D player = new Rigidbody2D();
    Vector2 movement;
    Vector2 mousePos;
    public int collectedParts = 0;
    //private int collectedParts = 0;
    public int health = 5;
    public Camera cam;
    public Animator animator;
    public float alphaLevel = 0f;
    //private SpriteRenderer _spriteRenderer;
    public Canvas canvas;
    public RawImage healthbar;
    public Texture newTexture;
    public GameObject winScreen;
    public GameObject gameOverScreen;
    Texture healthBar4;
    Texture healthBar3;
    Texture healthBar2;
    Texture healthBar1;
    Texture healthBar0;

    protected void Awake() {
        //_spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar4 = Resources.Load<Texture2D>("HealthBar/health-bar4.5");
        healthBar3 = Resources.Load<Texture2D>("HealthBar/health-bar3.5");
        healthBar2 = Resources.Load<Texture2D>("HealthBar/health-bar2.5");
        healthBar1 = Resources.Load<Texture2D>("HealthBar/health-bar1.5");
        healthBar0 = Resources.Load<Texture2D>("HealthBar/health-bar0.5");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
         
    }

    private void FixedUpdate()
    {
        player.MovePosition(player.position + (movement * moveSpeed * Time.fixedDeltaTime)); //Normalize(movement)

        Vector2 lookDir = mousePos - player.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        player.rotation = angle;
        cam.transform.position = new Vector3(player.position.x, player.position.y, cam.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickableItem"))
        {
            Destroy(other.gameObject);
            collectedParts++;
        }

        if (other.gameObject.CompareTag("LanternBattery"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("EscapeShip") && collectedParts==5)
        {
            Destroy(other.gameObject);
            canvas.gameObject.SetActive(false);
            winScreen.gameObject.SetActive(true);
            Die();
        }

        Enemy enemy = other.GetComponent<Enemy>();
       if (enemy != null)
       {
           //gameObject._spriteRenderer.color = new Color(1f,1f,1f,alphaLevel);
       }

    }

    public void incrementHealth()
    {
        health++;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        switch (health)
        {
            case 4:
                newTexture = healthBar4;
                healthbar.texture = newTexture;
                break;
            case 3:
                newTexture = healthBar3;
                healthbar.texture = newTexture;
                break;
            case 2:
                newTexture = healthBar2;
                healthbar.texture = newTexture;
                break;
            case 1:
                newTexture = healthBar1;
                healthbar.texture = newTexture;
                break;
            case 0:
                newTexture = healthBar0;
                healthbar.texture = newTexture;
                canvas.gameObject.SetActive(false);
                gameOverScreen.gameObject.SetActive(true);
                Die();
                break;
        }

    }

    void Die()
    {
        //Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    // private void Winner()
    // {
    //  if (this.collectedParts == 5)
    //  {
    // Scene.load("Winner");
    //  }
    // }

    //private void GameOver()
    //{
    // if (this.health <= 0)
    //  {
    //     // Scene.load("GameOver");
    //  }
    //  }
}
