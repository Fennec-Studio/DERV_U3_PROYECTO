using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    Transform jugador;
    [SerializeField] public float velocidad = 5.0f;
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Vector3 direccion = jugador.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);
    }
}
