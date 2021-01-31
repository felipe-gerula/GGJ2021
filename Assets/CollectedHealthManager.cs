using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CollectedHealthManager : MonoBehaviour
{
    public static CollectedHealthManager instance;
    int collectedHealth;
    public GameObject player;
    public RawImage healthbar;
    public Texture newTexture;
    Texture healthBar5;
    Texture healthBar4;
    Texture healthBar3;
    Texture healthBar2;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangePlayerHealth(GameObject battery)
    {
        int playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().health;
        if (playerHealth < 5)
        {
            playerHealth++;
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().incrementHealth();
            healthBar5 = Resources.Load<Texture2D>("HealthBar/health-bar5.5");
            healthBar4 = Resources.Load<Texture2D>("HealthBar/health-bar4.5");
            healthBar3 = Resources.Load<Texture2D>("HealthBar/health-bar3.5");
            healthBar2 = Resources.Load<Texture2D>("HealthBar/health-bar2.5");
            switch (playerHealth)
            {
                case 5:
                    newTexture = healthBar5;
                    healthbar.texture = newTexture;
                    break;
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
            }
            Destroy(battery);
        }
    }
}
