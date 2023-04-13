using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HintMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject hintBox;
    public Text message;
    private bool displaying = true;
    private bool overIcon = false;

    public int objectType = 0;

    private Vector3 screenpoint;
    public GameObject theCanvas;   
    public Sprite mainCursor;
    public Sprite cameraCursor;
    public Image cursorImage;

    private AudioSource audioPlayer;

    public GameObject inventoryObject;
    public bool magic = false;
    public bool spell = false;
    public bool left = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        overIcon = true;
        if(displaying == true)
        {
            cursorImage.sprite = cameraCursor;
            hintBox.SetActive(true);
            if (left == false)
            {
                screenpoint.x = Input.mousePosition.x + 400;
            }
            if (left == true)
            {
                screenpoint.x = Input.mousePosition.x - 400;
            }
            screenpoint.y = Input.mousePosition.y;
            screenpoint.z = 1f;
            hintBox.transform.position = Camera.main.ScreenToWorldPoint(screenpoint);
            MessageDisplay();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cursorImage.sprite = mainCursor;
        overIcon = false;
        hintBox.SetActive(false);
    }

    void Start()
    {
        hintBox.SetActive(false);
        audioPlayer = inventoryObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (overIcon == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioPlayer.clip = inventoryObject.GetComponent<InventoryItems>().selectIcon;
                audioPlayer.Play();
                displaying = false;
                hintBox.SetActive(false);
                if (magic == true)
                {
                    if(objectType != 0)
                    {
                        inventoryObject.GetComponent<InventoryItems>().selected = objectType - 20;
                        inventoryObject.GetComponent<InventoryItems>().set = true;
                    }
                }
                if (spell == true)
                {
                    if(objectType != 0)
                    {
                        inventoryObject.GetComponent<InventoryItems>().selected = objectType - 30;
                        inventoryObject.GetComponent<InventoryItems>().setTwo = true;
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            displaying = true;
        }
    }

    void MessageDisplay()
    {
        if(objectType == 0)
        {
            message.text = "empty";
        }
        if (objectType == 1)
        {
            message.text = InventoryItems.redMushroom.ToString() + " | Red Mushrooms is used to craft potions, save it for later.";
        }
        if (objectType == 2)
        {
            message.text = InventoryItems.purpleMushroom.ToString() + " | Purple Mushrooms is used to craft potions, save it for later.";
        }
        if (objectType == 3)
        {
            message.text = InventoryItems.brownMushroom.ToString() + " | Brown Mushrooms is used to craft potions, save it for later.";
        }
        if (objectType == 4)
        {
            message.text = InventoryItems.blueFlower.ToString() + " | Blue Flowers is used to craft potions, save it for later.";
        }
        if (objectType == 5)
        {
            message.text = InventoryItems.redFlower.ToString() + "| Red Flowers is used to craft potions, save it for later.";
        }
        if (objectType == 6)
        {
            message.text = InventoryItems.roots.ToString() + " Roots to be used in potions";
        }
        if (objectType == 7)
        {
            message.text = InventoryItems.leafDew.ToString() + " Leaf Dew to be used in potions";
        }
        if (objectType == 8)
        {
            message.text = "key to open chests";
        }
        if(objectType == 9)
        {
            message.text = InventoryItems.dragonEgg.ToString() + " Dragon egg to be used in potions";
        }
        if (objectType == 10)
        {
            message.text = InventoryItems.bluePotion.ToString() + " Blue potion to be used in potions";
        }
        if (objectType == 11)
        {
            message.text = InventoryItems.purplePotion.ToString() + " Purple potion to be used in potions";
        }
        if (objectType == 12)
        {
            message.text = InventoryItems.greenPotion.ToString() + " Green potion to be used in potions";
        }
        if (objectType == 13)
        {
            message.text = InventoryItems.redPotion.ToString() + " Red potion to be used in potions";
        }
        if (objectType == 14)
        {
            message.text = InventoryItems.bread.ToString() + " Bread used to replenish health";
        }
        if (objectType == 15)
        {
            message.text = InventoryItems.cheese.ToString() + " Cheese used to replenish health";
        }
        if (objectType == 16)
        {
            message.text = InventoryItems.meat.ToString() + " Meat used to replenish health";
        }



        if (objectType == 20)
        {
            message.text = "Explosive fire attack";
        }
        if (objectType == 21)
        {
            message.text = "Replenishes full health";
        }
        if (objectType == 22)
        {
            message.text = "Become invisible for as long as mana lasts";
        }
        if (objectType == 23)
        {
            message.text = "Become Invulnerability for as long as mana lasts";
        }
        if (objectType == 24)
        {
            message.text = "Doubles your strenght as long as mana lasts";
        }
        if (objectType == 25)
        {
            message.text = "Swirl attack";
        }

        

        if (objectType == 30)
        {
            message.text = "Spell Attack 1";
        }
        if (objectType == 31)
        {
            message.text = "Spell Attack 2";
        }
        if (objectType == 32)
        {
            message.text = "Spell Attack 3";
        }
        if (objectType == 33)
        {
            message.text = "Spell Attack 4";
        }
        if (objectType == 34)
        {
            message.text = "Spell Attack 5";
        }
        if (objectType == 35)
        {
            message.text = "Spell Attack 6";
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        theCanvas.GetComponent<CreatePotion>().thisValue = objectType;
        theCanvas.GetComponent<CreatePotion>().UpdateValues();
    }
}
