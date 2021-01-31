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
            switch (playerHealth)
            {
                case 5:
                    newTexture = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Animations/HealthBar/health-bar5.5.png", typeof(Texture));
                    healthbar.texture = newTexture;
                    break;
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
            }
            Destroy(battery);
        }
    }
}
