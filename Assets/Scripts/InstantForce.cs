using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantForce : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float fuerza = 50;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(transform.forward * fuerza * Time.deltaTime, ForceMode.Impulse);
    }
}
