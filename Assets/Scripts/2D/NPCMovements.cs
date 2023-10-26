using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovements : MonoBehaviour
{
    [SerializeField] float speed = 3.0f; // Velocidad de movimiento
    [SerializeField] float minZ = 880.0f; // Valor mínimo de Z
    [SerializeField] float maxZ = 889.0f; // Valor máximo de Z
    Animator enemyAnims;

    private int direction = -1;
    void Start()
    {
        enemyAnims = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentZ = transform.position.z;
        float newZ = currentZ + (speed * direction * Time.deltaTime);

        if (newZ < minZ)
        {
            newZ = minZ;
            direction = 1;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (newZ > maxZ)
        {
            newZ = maxZ;
            direction = -1;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        enemyAnims.SetBool("Walking", true);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
}
