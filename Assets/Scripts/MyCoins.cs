using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCoins : MonoBehaviour
{
    // Start is called before the first frame update
    float velocidadRotacion = 100;
    public AudioSource audioMoneda;
    void Start()
    {
        audioMoneda.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            Debug.Log("Ejecuta el colision player");
            Destroy(gameObject, 0.5f);
            int coinsCounter = PlayerPrefs.GetInt("mCoins");
            coinsCounter += 1;
            PlayerPrefs.SetInt("mCoins", coinsCounter);
            audioMoneda.Play();
        }
    }
}
