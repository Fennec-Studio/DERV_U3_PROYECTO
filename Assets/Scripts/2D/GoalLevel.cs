using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalLevel : MonoBehaviour
{
    [SerializeField] GameObject goalFlag;
    [SerializeField] AudioSource goalSound;
    //Vector3 posCamera = new Vector3(11.65491f, 12.15638f, 1085.225f);
    void Start()
    {
        goalSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

            foreach (AudioSource audioSource in allAudioSources)
            {
                audioSource.Stop();
            }

            GameObject auxPlayer = GameObject.Find("Mario");
            MovePlayer2D characterController = auxPlayer.GetComponent<MovePlayer2D>();
            Vector3 posFlag = new Vector3(11.65491f, 12.15638f, 1085.225f);

            Destroy(characterController, 1.0f);
            goalFlag.transform.position = posFlag;
            goalSound.Play();
            StartCoroutine(SecondLevel());
        }
    }

    private IEnumerator SecondLevel()
    {
        yield return new WaitForSeconds(6.0f);
        SceneManager.LoadScene("Level2");
    }
}
