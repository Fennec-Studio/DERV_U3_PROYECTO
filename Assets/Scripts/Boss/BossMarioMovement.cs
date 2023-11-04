using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMarioMovement : MonoBehaviour
{
    [SerializeField] float speed = 3.0f; // Velocidad de movimiento
    [SerializeField] Vector3[] targetCoordinates; // Coordenadas a seguir

    private int currentCoordinateIndex = 0;
    private Vector3 currentTarget;

    void Start()
    {
        currentTarget = targetCoordinates[currentCoordinateIndex];
    }

    void Update()
    {
        // Calcula la dirección hacia el siguiente conjunto de coordenadas.
        Vector3 direction = (currentTarget - transform.position).normalized;

        // Mueve el NPC hacia el siguiente conjunto de coordenadas.
        transform.Translate(direction * speed * Time.deltaTime);

        // Si el NPC está lo suficientemente cerca del conjunto de coordenadas actual, pasa al siguiente.
        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {
            currentCoordinateIndex++;
            if (currentCoordinateIndex >= targetCoordinates.Length)
            {
                currentCoordinateIndex = 0; // Vuelve al inicio si has llegado al final de las coordenadas.
            }
            currentTarget = targetCoordinates[currentCoordinateIndex];
            FlipSprite(currentTarget);
        }
    }

    void FlipSprite(Vector3 newTarget)
    {
        // Voltea el sprite según la dirección del nuevo objetivo.
        if (newTarget.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}