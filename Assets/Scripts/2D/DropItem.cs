using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] GameObject prize;
    [SerializeField] GameObject BlockUsed;
    [SerializeField] AudioSource prizeSound;

    private bool PrizeClaimed;
    void Start()
    {
        PrizeClaimed = false;
        prizeSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!PrizeClaimed)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                prize.SetActive(true);
                PrizeClaimed = true;
                gameObject.SetActive(false);
                BlockUsed.SetActive(true);
                if(prizeSound != null)
                {
                    prizeSound.Play();
                }

                if (prize.CompareTag("Coin"))
                {
                    Destroy(prize, 2.0f);
                    int coinsCounter = PlayerPrefs.GetInt("mCoins");
                    coinsCounter = coinsCounter + 1;
                    PlayerPrefs.SetInt("mCoins", coinsCounter);
                }
            }
        }
    }
}
