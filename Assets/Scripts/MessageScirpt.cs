using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MessageScirpt : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;
    public Text ShopOwnerMessage;
    public Color32 messageOff;
    public Color32 messageOn;
    public GameObject[] foodShopUI;
    [HideInInspector]
    public int shopNum;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = messageOn;
        PlayerMovement.canMove = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = messageOff;
        PlayerMovement.canMove = true;
    }

    void Start()
    {
        ShopOwnerMessage.text = "Hello" + SaveScript.pname + ", How can I help you?";   
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.moving == true && PlayerMovement.canMove == true)
        {
            if (foodShopUI != null)
            {
                foodShopUI[shopNum].SetActive(false);
            }
        }
    }

    public void Message1()
    {
        ShopOwnerMessage.text = "Nothing much going on here.";
    }

    public void Message2()
    {
        ShopOwnerMessage.text = "Select Items from the list.";
        foodShopUI[shopNum].SetActive(true);
        foodShopUI[shopNum].GetComponent<ShopScript>().UpdateGold();
    }
}
