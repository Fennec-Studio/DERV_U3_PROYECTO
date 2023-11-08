using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossMarioMovement : MonoBehaviour
{
    [SerializeField] float speed = 3.0f; // Velocidad de movimiento
    [SerializeField] float minX = 70.2f; // Valor mínimo de X
    [SerializeField] float maxX = 159.4f; // Valor máximo de X
    [SerializeField] TextMeshPro txtLifeBoss;
    [SerializeField] GameObject Ramp;
    [SerializeField] GameObject cameraPrize;
    [SerializeField] GameObject starPrize;
    [SerializeField] AudioSource lowHit;
    [SerializeField] AudioSource highHit;
    [SerializeField] AudioSource bowserLaugh;
    Animator enemyAnims;
    private bool isDown = false;
    private int lifeBoss = 100;
    private int direction = -1;
    private bool bossDefeat = false;
    private Rigidbody rbMario;

    void Start()
    {
        enemyAnims = GetComponent<Animator>();
        isDown = false;
        bossDefeat = false;
        lowHit.Stop();
        highHit.Stop();
        bowserLaugh.Stop();
        rbMario = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDown && lifeBoss > 0)
        {
            float currentX = transform.position.x;
            float newX = currentX + (speed * direction * Time.deltaTime);

            if (newX < minX)
            {
                newX = minX;
                direction = 1;
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
            else if (newX > maxX)
            {
                newX = maxX;
                direction = -1;
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            }

            enemyAnims.SetBool("Walking", true);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }

        if(lifeBoss <= 0 && !bossDefeat)
        {
            BossToDie();    
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isDown && lifeBoss > 0 && other.gameObject.CompareTag("Canon"))
        {
            isDown = true;
            enemyAnims.SetBool("Hitting", true);
            StartCoroutine(GiveUpBoss());
            lifeBoss -= 10;
            highHit.Play();
            txtLifeBoss.text = "<color=\"red\">" + lifeBoss + "/100♥";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isDown && lifeBoss > 0 && collision.gameObject.CompareTag("Canon"))
        {
            isDown = true;
            enemyAnims.SetBool("Hitting", true);
            StartCoroutine(GiveUpBoss());
            lifeBoss -= 5;
            lowHit.Play();
            txtLifeBoss.text = "<color=\"red\">" + lifeBoss + "/100♥";
        }
    }

    private IEnumerator GiveUpBoss()
    {
        yield return new WaitForSeconds(3.0f);
        enemyAnims.SetBool("Hitting", false);
        isDown = false;
    }

    private void BossToDie()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop();
        }

        bossDefeat = true;
        lifeBoss = 0;
        enemyAnims.SetBool("Dead", true);
        Ramp.SetActive(true);
        cameraPrize.SetActive(true);
        starPrize.SetActive(true);
        StartCoroutine(DisableDieCamera());
        rbMario.isKinematic = true;
        bowserLaugh.Play();
        Destroy(GameObject.Find("LAVA"));
    }

    private IEnumerator DisableDieCamera()
    {
        yield return new WaitForSeconds(5f);
        cameraPrize.SetActive(false);
    }
}