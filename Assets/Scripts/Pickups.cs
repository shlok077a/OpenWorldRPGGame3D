using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int number;
    public bool redMushroom = false;
    public bool purpleMushroom = false;
    public bool brownMushroom = false;
    public bool blueFlower = false;
    public bool redFlower = false;

    public GameObject inventoryObject;
    private AudioSource audioPlayer;

    void Start()
    {
        inventoryObject = GameObject.Find("InventoryCanvas");
        audioPlayer = inventoryObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioPlayer.clip = inventoryObject.GetComponent<InventoryItems>().pickupSound;
            audioPlayer.Play();
            if (redMushroom == true)
            {
                if (InventoryItems.redMushroom == 0)
                {
                    DisplayIcon();
                }
                InventoryItems.redMushroom++;
                Destroy(gameObject);
            } else if (blueFlower == true)
            {
                if (InventoryItems.blueFlower == 0)
                {
                    DisplayIcon();
                }
                InventoryItems.blueFlower++;
                Destroy(gameObject);            
            }else if (redFlower == true)
            {
                if (InventoryItems.redFlower == 0)
                {
                    DisplayIcon();
                }
                InventoryItems.redFlower++;
                Destroy(gameObject);
            }else if (purpleMushroom == true)
            {
                if (InventoryItems.purpleMushroom == 0)
                {
                    DisplayIcon();
                }       
                InventoryItems.purpleMushroom++;
                Destroy(gameObject);     
            }else if (brownMushroom == true)
            {
                if (InventoryItems.brownMushroom == 0)
                {
                    DisplayIcon();
                }       
                InventoryItems.brownMushroom++;
                Destroy(gameObject);  
            }else 
            {
                DisplayIcon();
                Destroy(gameObject);
            }
        }
    }

    void DisplayIcon()
    {
        InventoryItems.newIcon = number;
        InventoryItems.iconUpdate = true;
    }
}
