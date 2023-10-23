using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    // Start is called before the first frame update

    //public string nube1 = "FirstCloud";
    //public string nube2 = "SecondCloud";
    //public string nube3 = "ThirdCloud";
    public Transform destino;
    public Transform origen;
    float velocidadPlataforma = 2f;
    //bool firstPosition = true;

    void Start()
    {
        StartCoroutine(MoverNube());
    }

    // Update is called once per frame
    void Update()
    {
        //TranslateClouds();
    }

    void TranslateClouds()
    {
        //GameObject moveCloud1 = GameObject.Find(nube1);
        //GameObject moveCloud2 = GameObject.Find(nube2);
        //GameObject moveCloud3 = GameObject.Find(nube3);

        //if (firstPosition)
        //{
        //    transform.Translate(Vector3.right * velocidadPlataforma * Time.deltaTime);
            //firstPosition = false;
            //moveCloud1.transform.transform.position = new Vector3(0f,1f, 0f) * velocidadPlataforma * Time.deltaTime;
            //moveCloud2.transform.transform.position = new Vector3(1f, 0f, 0f) * velocidadPlataforma * Time.deltaTime;
            //moveCloud3.transform.transform.position = new Vector3(1f, 0f, 0f) * velocidadPlataforma * Time.deltaTime;
        //}
        //else
        //{
        //    transform.Translate(Vector3.left * velocidadPlataforma * Time.deltaTime);
        //}
    }

    IEnumerator MoverNube()
    {
        while (true)
        {
            // Mueve el objeto hacia el punto de destino
            while (Vector3.Distance(transform.position, destino.position) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidadPlataforma * Time.deltaTime);
                yield return null;
            }

            // Espera un momento (puedes ajustar la duración del tiempo de espera)
            yield return new WaitForSeconds(1.0f);

            // Mueve el objeto de regreso a su posición original
            while (Vector3.Distance(transform.position, origen.position) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, origen.position, velocidadPlataforma * Time.deltaTime);
                yield return null;
            }

            // Espera un momento antes de comenzar el próximo ciclo (puedes ajustar la duración del tiempo de espera)
            yield return new WaitForSeconds(1.0f);
        }
    }
}
