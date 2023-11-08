using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaCollision : MonoBehaviour
{
    public float tiempoTotal = 240.0f;
    private float tiempoTranscurrido = 0.0f;
    private Transform objetoAMover;
    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    void Start()
    {
        objetoAMover = transform;
        posicionInicial = objetoAMover.position;
        posicionFinal = new Vector3(objetoAMover.position.x, 7.0f, objetoAMover.position.z);
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido > tiempoTotal)
        {
            tiempoTranscurrido = tiempoTotal;
        }
        float t = tiempoTranscurrido / tiempoTotal;
        objetoAMover.position = Vector3.Lerp(posicionInicial, posicionFinal, t);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            int lifes = PlayerPrefs.GetInt("mLifes");
            lifes = lifes - 1;
            PlayerPrefs.SetInt("mLifes", lifes);
            SceneManager.LoadScene("FinalBoss");
        }
    }
}