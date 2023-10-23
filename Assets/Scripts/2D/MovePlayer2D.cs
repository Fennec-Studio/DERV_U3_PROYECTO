using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer2D : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce = 8.0f;
    [SerializeField] AudioSource jumpSound;
    private Rigidbody rb;
    private bool lookForward;
    private bool isJumping;

    public Animator walkAnim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lookForward = true;
        isJumping = false;
        walkAnim = GetComponent<Animator>();
        jumpSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            if (!lookForward)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                lookForward = true;
            }

            transform.Translate(transform.forward * speed * Time.deltaTime);
            walkAnim.SetBool("IsWalking", true);
        } else if (Input.GetKey(KeyCode.A))
        {
            lookForward = false;
            transform.Translate(transform.forward * -1 * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            walkAnim.SetBool("IsWalking", true);
        } else
        {
            walkAnim.SetBool("IsWalking", false);
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        if (transform.position.y <= 8)
        {
            int lifes = PlayerPrefs.GetInt("mLifes");
            lifes = lifes - 1;
            PlayerPrefs.SetInt("mLifes", lifes);
            SceneManager.LoadScene("Level1");
        }
    }

    void Jump()
    {
        if(!isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            walkAnim.SetBool("IsJump", true);
            jumpSound.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("IsSolid"))
        {
            isJumping = false;
            walkAnim.SetBool("IsJump", false);
        }
    }
}
