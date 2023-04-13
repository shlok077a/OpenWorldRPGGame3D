using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject openBook;
    public GameObject closedBook;
    public GameObject messageBox;
    public GameObject magicBook;

    private AudioSource audioPlayer;
    public AudioClip bookOpenCloseSound;
    public AudioClip selectIcon;
    public AudioClip buySound;
    public AudioClip createPotion;
    public AudioClip pickupSound;

    public Image[] emptySlots;
    public Sprite[] imageSprites;
    public Sprite emptyIcon;

    public static int newIcon = 0;
    public static bool iconUpdate = false;
    private int max;

    public static int redMushroom = 0;
    public static int purpleMushroom = 0;
    public static int brownMushroom = 0;
    public static int blueFlower = 0;
    public static int redFlower = 0;
    public static int roots = 0;
    public static int leafDew = 0;
    public static int dragonEgg = 0;
    public static int redPotion = 0;
    public static int bluePotion = 0;
    public static int greenPotion = 0;
    public static int purplePotion = 0;
    public static int bread = 0;
    public static int cheese = 0;
    public static int meat = 0;
    public static bool key = true;
    public static int gold = 30000;
    [HideInInspector]
    public string entry;
    public string[] items;
    [HideInInspector]
    public int currentID = 0;
    [HideInInspector]
    public int checkAmt = 0;
    private int maxTwo;
    private int maxThree;
    public GameObject theCanvas;

    public Image[] UISlots;
    public Sprite[] magicIcons; 
    public Sprite[] spellIcons;
    public KeyCode[] keys;
    public bool set = false;
    public bool setTwo = false;
    [HideInInspector]
    public int selected;
    public int[] magicAttack;

    public GameObject magicParticle;

    void Start()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        max = emptySlots.Length;
        maxTwo = items.Length;
        maxThree = imageSprites.Length;
        magicBook.SetActive(false);
        audioPlayer = GetComponent<AudioSource>();
        

        redMushroom = 0;
        purpleMushroom = 0;
        brownMushroom = 0;
        blueFlower = 0;
        redFlower = 0;
        roots = 0;
        leafDew = 0;
        bluePotion = 0;
        greenPotion = 0;
        purplePotion = 0;
        redPotion = 0;
        bread = 0;
        cheese = 0;
        meat = 0;


    }

    void Update()
    {
        if (iconUpdate == true)
        {
            for (int i = 0; i < max; i++)
            {
                if (emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = imageSprites[newIcon];
                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = newIcon;
                }
            }
        StartCoroutine(Reset());
        }
        if (set == true)
        {
            
            for(int i = 0; i < UISlots.Length; i++)
            {
                if(Input.GetKeyDown(keys[i]))
                {
                    set = false;
                    UISlots[i].sprite = magicIcons[selected];
                    magicAttack[i] = selected;
                    theCanvas.GetComponent<CreatePotion>().Remove(selected);

                }
            }
        }

        if (setTwo == true)
        {
            
            for(int i = 0; i < UISlots.Length; i++)
            {
                if(Input.GetKeyDown(keys[i]))
                {
                    setTwo = false;
                    UISlots[i].sprite = spellIcons[selected];
                    magicAttack[i] = selected += 6;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(magicParticle, SaveScript.spawnPoint.transform.position, SaveScript.spawnPoint.transform.rotation);
        }
    }

    public void CheckStatics()
    {
        for(int i = 0; i < maxTwo; i++)
        {
            if(i == currentID)
            {
                maxTwo = i;
                entry = items[i];
                checkAmt = System.Convert.ToInt32(typeof(InventoryItems).GetField(entry).GetValue(null));
                checkAmt--;
                typeof(InventoryItems).GetField(entry).SetValue(null, checkAmt);
                if(checkAmt == 0)
                {
                    RemoveIcon(i);
                }
            }
        }
        maxTwo = items.Length;
    }

    public void RemoveIcon(int iconType)
    {
        for(int i = 0; i < maxThree; i++)
        {
            if(emptySlots[i].sprite == imageSprites[iconType])
            {
                maxThree = i;
                emptySlots[i].sprite = imageSprites[0];
                emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = 0;
            }
        }
        maxThree = emptySlots.Length;
    }


    public void OpenBook()
    {
        messageBox.SetActive(false);
        inventoryMenu.SetActive(true);
        openBook.SetActive(true);
        closedBook.SetActive(false);
        audioPlayer.clip = bookOpenCloseSound;
        audioPlayer.Play();
        Time.timeScale = 0;
    }

    public void ClosedBook()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        audioPlayer.clip = bookOpenCloseSound;
        audioPlayer.Play();
        Time.timeScale = 1;
    }

    public void OpenMagicBook()
    {
        magicBook.SetActive(true);
    }

    public void CloseMagicBook()
    {
        magicBook.SetActive(false);
        theCanvas.GetComponent<CreatePotion>().thisValue = 0;
        theCanvas.GetComponent<CreatePotion>().value = 0;
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.01f);
        iconUpdate = false;
        max = emptySlots.Length;
    }
}
