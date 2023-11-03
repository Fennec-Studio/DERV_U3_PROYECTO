using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] GameObject objProyectil;
    [SerializeField] GameObject ubiLanzamiento;
    float timeToDestroy = 3.0f;
    float intervaloDeTiempo = 0.0f;

    float tiempoPasado = 0.0f;
    void Start()
    {
        intervaloDeTiempo = Random.Range(0.0f, 6.0f);
    }

    void Update()
    {
        tiempoPasado += Time.deltaTime;

        if (tiempoPasado >= intervaloDeTiempo)
        {
            GameObject obj = Instantiate(objProyectil, ubiLanzamiento.transform.position,
                ubiLanzamiento.transform.rotation);

            Destroy(obj, timeToDestroy);

            intervaloDeTiempo = Random.Range(0.0f, 6.0f);
            tiempoPasado = 0.0f;
        }
    }
}
