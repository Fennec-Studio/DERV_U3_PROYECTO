using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBonusCollect : MonoBehaviour
{
    public AudioSource prueba;
    void Start()
    {
        prueba.Stop();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.5f);
        int coinsCounter = PlayerPrefs.GetInt("mCoins");
        coinsCounter = coinsCounter + 1;
        PlayerPrefs.SetInt("mCoins", coinsCounter);
        prueba.Play();
    }
}
