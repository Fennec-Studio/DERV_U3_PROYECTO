using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZoneL2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string cargarEscena;

    public AudioSource dieSound;

    void Start()
    {
            dieSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        int lifes = PlayerPrefs.GetInt("mLifes");
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Si");
            SceneManager.LoadScene(cargarEscena);
            lifes = lifes - 1;
            PlayerPrefs.SetInt("mLifes", lifes);
            dieSound.Play();
        }
        //if (collider.CompareTag("Player") && lifes <= 0)
        //{
        //    dieSound.Play();
        //    SceneManager.LoadScene(cargarEscena);
        //}
    }
}
