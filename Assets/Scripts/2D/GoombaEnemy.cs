using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoombaEnemy : MonoBehaviour
{
    private bool isDead;
    [SerializeField] AudioSource goombaDie;
    void Start()
    {
        goombaDie.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isDead)
            {
                int lifes = PlayerPrefs.GetInt("mLifes");
                int isGiant = PlayerPrefs.GetInt("mGiant");
                if (isGiant == 0)
                {
                    lifes = lifes - 1;
                    PlayerPrefs.SetInt("mLifes", lifes);
                    SceneManager.LoadScene("Level1");
                }
                else
                {
                    PlayerPrefs.SetInt("mGiant", 0);
                    Vector3 newScale = new Vector3(0.5f, 0.5f, 0.5f);
                    GameObject player = GameObject.Find("Mario");

                    player.transform.localScale = newScale;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            goombaDie.Play();
            isDead = true;
            Vector3 newScale = new Vector3(0.7f, 0.2f, 0.7f);
            transform.localScale = newScale;

            Destroy(gameObject, 0.3f);
        }
    }
}
