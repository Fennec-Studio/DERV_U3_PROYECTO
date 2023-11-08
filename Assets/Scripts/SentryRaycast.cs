using UnityEngine;
using UnityEngine.SceneManagement;

public class SentryRaycast : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 45.0f; // Velocidad de rotación
    [SerializeField] float raycastDistance = 10.0f;
    [SerializeField] float raycastHeightOffset = 1.0f; // Ajuste de altura del rayo
    [SerializeField] AudioSource dieSound;
    string nivel;

    void Start()
    {
        nivel = SceneManager.GetActiveScene().name;
        dieSound.Stop();
    }

    void Update()
    {
        // Obtén la posición del inicio del rayo con la elevación
        Vector3 rayStart = transform.position + Vector3.up * raycastHeightOffset;

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        Ray ray = new Ray(rayStart, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                int lifes = PlayerPrefs.GetInt("mLifes");
                lifes = lifes - 1;
                PlayerPrefs.SetInt("mLifes", lifes);
                PlayerPrefs.SetInt("mBonus", 0);
                SceneManager.LoadScene(nivel == "PipeBonus" ? "Level1" : nivel);
                dieSound.Play();
                SceneManager.LoadScene(nivel == "PipeBonus" ? "Level1" : nivel);
            }
        }
    }
}
