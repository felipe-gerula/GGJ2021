using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D player = new Rigidbody2D();
    Vector2 movement;
    Vector2 mousePos;
    public int collectedParts = 0;
    //private int collectedParts = 0;
    //public int health = 100;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
         
    }

    private void FixedUpdate()
    {
        player.MovePosition(player.position + (movement * moveSpeed * Time.fixedDeltaTime)); //Normalize(movement)

        Vector2 lookDir = mousePos - player.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        player.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickableItem"))
        {
            Destroy(other.gameObject);
            collectedParts++;
        }
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
