using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    private AudioSource auidoPlayer;
    public WaitForSeconds waitTime = new WaitForSeconds(4);
    void Start()
    {
        auidoPlayer = GetComponent<AudioSource>();
        StartCoroutine(AnimalSound());
    }

    IEnumerator AnimalSound()
    {
        yield return waitTime;
        auidoPlayer.Play();
        StartCoroutine(AnimalSound());
    }
}
