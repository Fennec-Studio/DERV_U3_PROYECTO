using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConkdorAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private bool animAttack = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && !animAttack)
        {
            animator.SetBool("Attack", true);
            animAttack = true;
        }
    }
}
