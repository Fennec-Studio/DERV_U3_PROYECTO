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
    Animator enemyAnims;
    private bool isDown = false;
    private int lifeBoss = 100;
    private int direction = -1;

    void Start()
    {
        enemyAnims = GetComponent<Animator>();
        isDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDown)
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isDown && other.gameObject.CompareTag("Canon"))
        {
            isDown = true;
            enemyAnims.SetBool("Hitting", true);
            StartCoroutine(GiveUpBoss());
            lifeBoss -= 10;
            txtLifeBoss.text = "<color=\"red\">" + lifeBoss + "/100♥";
        }
    }

    private IEnumerator GiveUpBoss()
    {
        yield return new WaitForSeconds(3.0f);
        enemyAnims.SetBool("Hitting", false);
        isDown = false;
    }
}