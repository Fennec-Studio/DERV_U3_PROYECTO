using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera2D : MonoBehaviour
{
    Transform Jugador;
    [SerializeField] float incremento;
    void Start()
    {
        Jugador = GameObject.Find("Mario").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posCamera = transform.position;
        posCamera.y = Jugador.position.y + incremento;
        if(posCamera.y < 15f)
        {
            transform.position = posCamera;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.Translate(transform.forward * -1 * 5 * Time.deltaTime);
        }
    }
}
