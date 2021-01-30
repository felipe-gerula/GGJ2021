using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickablePart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectedPartsManager.instance.ChangeCollectedParts();
        }
    }
}
