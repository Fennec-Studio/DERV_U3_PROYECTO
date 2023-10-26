using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroomprizes : MonoBehaviour
{
    [SerializeField] AudioSource collectedMushroom;
    GameObject Player;
    private MovePlayer2D movePlayerScript;
    void Start()
    {
        Player = GameObject.Find("Mario"); 
        movePlayerScript = Player.GetComponent<MovePlayer2D>();
        collectedMushroom.Stop();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Delimiter"))
        {
            Vector3 newScale = new Vector3(1.0f, 1.0f, 1.0f);
            Player.transform.localScale = newScale;
            collectedMushroom.Play();
            Destroy(gameObject);
            PlayerPrefs.SetInt("mGiant", 1);
        }
    }
}
