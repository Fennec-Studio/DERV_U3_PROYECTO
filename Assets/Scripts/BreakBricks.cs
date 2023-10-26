using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBricks : MonoBehaviour
{
    [SerializeField] GameObject breakBrick;
    [SerializeField] AudioSource breakBrickSound;
    void Start()
    {
        breakBrickSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            breakBrick.SetActive(true);
            breakBrickSound.Play();
            Destroy(breakBrick, 0.2f);
        }
    }
}
