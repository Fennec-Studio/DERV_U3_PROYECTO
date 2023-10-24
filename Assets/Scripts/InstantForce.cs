using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantForce : MonoBehaviour
{
    Rigidbody rb;
    float fuerza;

    // Start is called before the first frame update
    void Start()
    {
        fuerza = 50;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * fuerza * Time.deltaTime, ForceMode.Impulse);
    }
}
