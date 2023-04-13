using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofScript : MonoBehaviour
{
    public GameObject roof;
    public GameObject props;
    public GameObject mainCamera;
    public bool tavern = true;

    void Start()
    {
        roof.SetActive(true);
        props.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            roof.SetActive(false);
            props.SetActive(true);
            if(tavern == true)
            {
                mainCamera.GetComponent<AudioManager>().musicState = 2;
                mainCamera.GetComponent<AudioManager>().canPlay = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            roof.SetActive(true);
            props.SetActive(false);
            if(tavern == true)
            {
                mainCamera.GetComponent<AudioManager>().musicState = 1;
                mainCamera.GetComponent<AudioManager>().canPlay = true;
            }
        }
    }
}
