using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] GameObject objProyectil;
    [SerializeField] GameObject ubiLanzamiento;
    [SerializeField] int timeToDestroy;

    float intervaloDeTiempo = 2.0f; // Intervalo de tiempo en segundos
    float tiempoPasado = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tiempoPasado += Time.deltaTime;

        if (tiempoPasado >= intervaloDeTiempo)
        {
            GameObject obj = Instantiate(objProyectil, ubiLanzamiento.transform.position,
                ubiLanzamiento.transform.rotation);

            Destroy(obj, timeToDestroy);

            tiempoPasado = 0.0f;
        }
    }
}
