using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectedPartsManager : MonoBehaviour
{

    public static CollectedPartsManager instance;
    public TextMeshProUGUI text;
    int collectedParts;
    Light shipBeacon;
    EdgeCollider2D shipCollider;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }    
    }

    public void ChangeCollectedParts()
    {
        collectedParts += 1;
        if (collectedParts < 5)
        {
            text.text = collectedParts.ToString() + " / 5";
        } else
        {
            text.text = "You can now search for the ship";
            text.color = Color.green;
            shipBeacon = GameObject.FindWithTag("ShipBeacon").GetComponent<Light>();
            shipBeacon.color = Color.green; //Rojo: CC2924
            shipCollider = GameObject.FindWithTag("EscapeShip").GetComponent<EdgeCollider2D>();
            shipCollider.isTrigger = true;
        }
    }
}
