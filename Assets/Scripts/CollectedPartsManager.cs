using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectedPartsManager : MonoBehaviour
{

    public static CollectedPartsManager instance;
    public TextMeshProUGUI text;
    int collectedParts;

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
            text.text = "Ya puedes buscar la nave";
        }
    }
}
