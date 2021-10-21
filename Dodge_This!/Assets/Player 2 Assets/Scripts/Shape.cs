using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public Rigidbody rb;
    public float shapeSpeed = 2f;
    public bool moving = true;
    void Start()
    {
        
    }

    void Update()
    {
        if (moving)
        {
            rb.AddForce(transform.forward * shapeSpeed, ForceMode.Impulse);
        }
    }
}
