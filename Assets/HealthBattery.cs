using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBattery : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectedHealthManager.instance.ChangePlayerHealth(gameObject);
        }
    }
}
