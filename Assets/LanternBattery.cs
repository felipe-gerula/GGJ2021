﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternBattery : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectedBatteriesManager.instance.ChangeCollectedBatteries();
        }
    }
}
