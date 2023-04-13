using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMover : MonoBehaviour
{
   
    public GameObject target;
    public GameObject obj;
    public float speed = 5f;
    public float lifeTime = 1.5f;
    public bool enemySeeker = false;
    public bool nonMoving = false;
    private GameObject targetSave;

    void Start()
    {
        targetSave = SaveScript.theTarget;
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.LerpUnclamped(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        if (enemySeeker == true)
        {
            if (targetSave != null)
            {
                transform.position = Vector3.LerpUnclamped(transform.position, targetSave.transform.position, speed * Time.deltaTime);
            }else 
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
        Destroy(obj, lifeTime);
    }
}
