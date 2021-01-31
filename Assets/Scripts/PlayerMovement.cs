using System.Collections;
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

    protected void Awake() {
        //_spriteRenderer = GetComponent<SpriteRenderer>();
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

        Enemy enemy = other.GetComponent<Enemy>();
       if (enemy != null)
       {
           //gameObject._spriteRenderer.color = new Color(1f,1f,1f,alphaLevel);
       }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        switch (health)
        {
            case 4:
                newTexture = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Animations/HealthBar/health-bar4.5.png", typeof(Texture));
                healthbar.texture = newTexture;
                break;
            case 3:
                newTexture = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Animations/HealthBar/health-bar3.5.png", typeof(Texture));
                healthbar.texture = newTexture;
                break;
            case 2:
                newTexture = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Animations/HealthBar/health-bar2.5.png", typeof(Texture));
                healthbar.texture = newTexture;
                break;
            case 1:
                newTexture = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Animations/HealthBar/health-bar1.5.png", typeof(Texture));
                healthbar.texture = newTexture;
                break;
            case 0:
                newTexture = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Animations/HealthBar/health-bar0.5.png", typeof(Texture));
                healthbar.texture = newTexture;
                break;
        }

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
