using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionsItems : MonoBehaviour
{
    public GameObject theCanvas;
    public int objID;
    [HideInInspector]
    public Image thisImage;
    [HideInInspector]
    public Color32 startColor = new Color32(255, 255, 255, 160);
    [HideInInspector]
    public Color32 endColor = new Color32(255, 255, 255, 255);

    public GameObject inventory;
    private bool check = true;

    void Start()
    {
    thisImage = GetComponent<Image>();
    }

    void Update()
    {
        if(theCanvas.GetComponent<CreatePotion>().thisValue == objID)
        {
            thisImage.color = endColor;
            if(check == true)
            {
                check = false;
                inventory.GetComponent<InventoryItems>().currentID = objID;
                inventory.GetComponent<InventoryItems>().CheckStatics();
            }
        }
        if (theCanvas.GetComponent<CreatePotion>().thisValue == 0)
        {
            check = true;
            thisImage.color = startColor;
        }
    }
}
