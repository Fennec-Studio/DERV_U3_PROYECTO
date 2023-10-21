using UnityEngine;

public class ItemsMovements : MonoBehaviour
{
    [SerializeField] float velocidad = 5.0f;
    private bool moviendoseHaciaAdelante = true;

    private void FixedUpdate()
    {
        if (moviendoseHaciaAdelante)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * velocidad * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            moviendoseHaciaAdelante = !moviendoseHaciaAdelante;
        }
    }
}
