using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBullet : MonoBehaviour
{
    public float velocidad = 10.0f;
    public float rotacionSpeed = 100.0f;

    private Rigidbody rb;
    private Collider tunnelCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tunnelCollider = GameObject.Find("Tunnel").GetComponent<Collider>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float rotacionY = horizontalInput * rotacionSpeed * Time.deltaTime;
        float rotacionX = verticalInput * rotacionSpeed * Time.deltaTime;
        transform.Rotate(rotacionX, rotacionY, 0);
        Vector3 movimiento = transform.forward * velocidad;
        rb.velocity = movimiento;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Tunnel"))
        {
            int lifes = PlayerPrefs.GetInt("mLifes");
            lifes = lifes - 1;
            PlayerPrefs.SetInt("mLifes", lifes);
            SceneManager.LoadScene("Level4");
        }
        if (other.gameObject.CompareTag("Delimite"))
        {
            SceneManager.LoadScene("FinalBoss");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        int lifes = PlayerPrefs.GetInt("mLifes");
        lifes = lifes - 1;
        PlayerPrefs.SetInt("mLifes", lifes);
        SceneManager.LoadScene("Level4");
    }
}
