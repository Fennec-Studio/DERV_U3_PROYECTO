using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCannon : MonoBehaviour
{
    [SerializeField] GameObject canon;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject launchBall;

    private float timeToDestroy = 3.0f;
    private Animator switchAnim;
    private Animator canonAnim;
    private bool CanonUsed = false;
    void Start()
    {
        CanonUsed = false;
        switchAnim = GetComponent<Animator>();
        canonAnim = canon.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!CanonUsed)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject obj = Instantiate(ball, launchBall.transform.position,
                    launchBall.transform.rotation);
                if(obj != null)
                {
                    Destroy(obj, timeToDestroy);
                }
                switchAnim.SetBool("Use", true);
                canonAnim.SetBool("WaitHit", true);
                StartCoroutine(ChangeCannonState());
                CanonUsed = true;
            }
        }
    }

    private IEnumerator ChangeCannonState()
    {
        yield return new WaitForSeconds(10.0f);
        CanonUsed = false;
        switchAnim.SetBool("Use", false);
        canonAnim.SetBool("WaitHit", false);
    }
}
