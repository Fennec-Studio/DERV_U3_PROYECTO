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
            if (characterAnims == null) return;
            characterAnims.SetBool("Walking", true);
        }
        else
        {
            if (characterAnims == null) return;
            characterAnims.SetBool("Walking", false);
        }

        if (characterController.isGrounded)
        {
            Debug.Log("Está en el suelo");
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Salto");
                float currentGravity = Physics.gravity.y;
                float jumpVelocity = Mathf.Sqrt(2 * jumpForce * Mathf.Abs(currentGravity));
                movimiento.y = jumpVelocity;
            }
        }

        characterController.Move(movimiento * Time.deltaTime);
    }
}
