using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choose : MonoBehaviour
{
    public GameObject[] Characters;
    int p = 0;
    public Text nameText;

    void Start()
    {
        
    }

    public void Next()
    {
        if (p < Characters.Length - 1)
        {
            Characters[p].SetActive(false);
            p++;
            Characters[p].SetActive(true);
        }        
    }

    public void Back()
    {
        if (p > 0)
        {
            Characters[p].SetActive(false);
            p--;
            Characters[p].SetActive(true);
        }        
    }

    public void Accept()
    {
        SaveScript.pchar = p;
        SaveScript.pname = nameText.text;
        SceneManager.LoadScene(1);
    }
}
