using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedBatteriesManager : MonoBehaviour
{
    public static CollectedBatteriesManager instance;
    int collectedBatteries;
    Light playerLantern;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeCollectedBatteries()
    {
        collectedBatteries++;
        playerLantern = GameObject.FindWithTag("PlayerLanternLight").GetComponent<Light>();
        playerLantern.range += .5f;
        playerLantern.intensity += 1;
    }
}
