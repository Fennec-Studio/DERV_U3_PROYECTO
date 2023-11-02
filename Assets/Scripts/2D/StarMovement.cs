using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarMovement : MonoBehaviour
{
    [SerializeField] float velocidad = 5.0f;
    [SerializeField] AudioSource worldSound;
    private bool moviendoseHaciaAdelante = true;
    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (moviendoseHaciaAdelante)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * velocidad * Time.deltaTime);
        }

        if (transform.position.y <= 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            body.AddForce(Vector3.up * 15, ForceMode.Impulse);
        }
    }
}