using UnityEngine;
using UnityEngine.SceneManagement;

public class SentryRaycast : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 45.0f; // Velocidad de rotaci�n
    [SerializeField] float raycastDistance = 10.0f;
    [SerializeField] float raycastHeightOffset = 1.0f; // Ajuste de altura del rayo
    [SerializeField] AudioSource dieSound;

    void Start()
    {
        dieSound.Stop();
    }

    void Update()
    {
        // Obt�n la posici�n del inicio del rayo con la elevaci�n
        Vector3 rayStart = transform.position + Vector3.up * raycastHeightOffset;

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        Ray ray = new Ray(rayStart, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                dieSound.Play();
                SceneManager.LoadScene("Level1");
            }
        }
    }
}