using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTargt : MonoBehaviour
{
    public float speed = 1.0f;
    public bool rotator = false;
    public bool particleTargt = true;

    void Update()
    {
        if (rotator == true)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
        if (particleTargt == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
