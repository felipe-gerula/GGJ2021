using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public GameObject hitEffect;
    public Rigidbody2D rb;
    
    void OnTriggerEnter2D(Collider2D other) {
       PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
       if (playerMovement != null)
       {
           playerMovement.TakeDamage(1);
       }
   }
}
