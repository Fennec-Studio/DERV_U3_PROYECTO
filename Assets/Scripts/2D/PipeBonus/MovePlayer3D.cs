using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer3D : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jump;
    [SerializeField] GameObject character;

    private Transform cameraTransform;
    private Rigidbody rb;
    private float rotationY = 0f;
    public float rotationSpeed = 5.0f;

    void Start()
    {
        rb = character.GetComponent<Rigidbody>();
        cameraTransform = transform.Find("Mario/Camera");
    }

    void Update()
    {
        // Movimiento del jugador
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(transform.forward * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.right * -speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }

        // Rotaci�n de la c�mara alrededor del personaje
        RotateCameraAroundCharacter();
    }

    void RotateCameraAroundCharacter()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Aplica rotaci�n horizontal a la c�mara.
        cameraTransform.Rotate(Vector3.up, mouseX * rotationSpeed);

        // Aplica rotaci�n vertical a la c�mara.
        rotationY -= mouseY * rotationSpeed;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(rotationY, 0, 0);

        // Aplica rotaci�n al eje Y del personaje.
        //character.transform.Rotate(Vector3.up, mouseX * rotationSpeed);
        transform.Rotate(Vector3.up, mouseX * rotationSpeed);
    }
}
