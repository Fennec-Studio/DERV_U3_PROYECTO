using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float speedRot = 2.0f;
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] GameObject character;
    Animator characterAnims;
    private CharacterController characterController;

    private float rotacionVertical = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        characterAnims = character.GetComponent<Animator>();
    }

    void Update()
    {
        // Rotación de la cámara con el mouse
        float rotacionHorizontal = Input.GetAxis("Mouse X") * speedRot;
        rotacionVertical -= Input.GetAxis("Mouse Y") * speedRot;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -90, 90);
        transform.Rotate(0, rotacionHorizontal, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(rotacionVertical, 0, 0);

        // Movimiento del personaje
        float movimientoFrontal = Input.GetAxis("Vertical") * speed;
        float movimientoLateral = Input.GetAxis("Horizontal") * speed;

        Vector3 movimiento = new Vector3(movimientoLateral, 0, movimientoFrontal);
        movimiento = transform.rotation * movimiento;
        
        if (movimiento.magnitude > 0)
        {
            characterAnims.SetBool("Walking", true);
        }
        else
        {
            characterAnims.SetBool("Walking", false);
        }

        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                movimiento.y = jumpForce;
            }
        }
        movimiento.y -= 9.8f * Time.deltaTime * 5;
        characterController.Move(movimiento * Time.deltaTime);
    }
}
