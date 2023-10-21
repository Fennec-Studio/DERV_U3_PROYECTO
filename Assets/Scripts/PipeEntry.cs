using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeEntry : MonoBehaviour
{
    [SerializeField] GameObject playerToAnim;
    [SerializeField] AudioSource pipeEntrySound;
    private bool isOnPipeEntry;
    private Animator animsPlayer;
    private Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        isOnPipeEntry = false;
        animsPlayer = playerToAnim.GetComponent<Animator>();
        playerRB = playerToAnim.GetComponent<Rigidbody>();
        pipeEntrySound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnPipeEntry)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                playerToAnim.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                animsPlayer.SetBool("IntoPipe", true);

                BoxCollider playerCollider = playerToAnim.GetComponent<BoxCollider>();
                playerCollider.enabled = false;
                pipeEntrySound.Play();
                StartCoroutine(GoToPipe());
            }
        }
    }

    private IEnumerator GoToPipe()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("PipeBonus");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isOnPipeEntry = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnPipeEntry = false;
        }
    }
}
