using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    public GameObject[] characters;
    public Transform spawnPoint;

    void Start()
    {
        Instantiate(characters[SaveScript.pchar], spawnPoint.position, spawnPoint.rotation);
    }
}
