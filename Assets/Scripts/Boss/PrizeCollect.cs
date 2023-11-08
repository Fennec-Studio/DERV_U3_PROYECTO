using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrizeCollect : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("Credits");
        }
    }
}
