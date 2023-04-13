using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject enemy;
    private bool outlineOn = false;

    void Start()
    {
        enemy.GetComponent<Outline>().enabled = false;
    }

    void Update()
    {
        if (outlineOn == false)
        {
            outlineOn = true;
            if (SaveScript.theTarget == enemy)
            {
                enemy.GetComponent<Outline>().enabled = true;
            }
        }

        if (outlineOn == true)
        {
            if (SaveScript.theTarget != enemy)
            {
                enemy.GetComponent<Outline>().enabled = false;
                outlineOn = false;
            }
        }
    }
}
