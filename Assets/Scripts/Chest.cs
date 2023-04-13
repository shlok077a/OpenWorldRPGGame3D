using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    public int GoldAmt = 100;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InventoryItems.key == true)
            {
                anim.SetTrigger("Open");
                InventoryItems.gold += GoldAmt;
                GoldAmt = 0;
                Debug.Log("Gold Amount = " + InventoryItems.gold);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InventoryItems.key == true)
            {
                anim.SetTrigger("Closed");
            }
        }
    }

    public void DestroyChest()
    {
        Destroy(gameObject);
    }
}
