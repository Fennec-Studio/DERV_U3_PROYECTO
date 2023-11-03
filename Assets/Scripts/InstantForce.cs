using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantForce : MonoBehaviour
{
    Rigidbody rb;
    float fuerza;

    void Start()
    {
        fuerza = 50;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(transform.forward * fuerza * Time.deltaTime, ForceMode.Impulse);
    }
}
