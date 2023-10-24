using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateCoin : MonoBehaviour
{
    // Start is called before the first frame update

    float velocidadRotacion = 100;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }

}
