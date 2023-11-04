using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] GameObject cinematicObject;
    [SerializeField] GameObject FPS;
    private void Start()
    {
        StartCoroutine(Cinematicfinished());
    }

    IEnumerator Cinematicfinished()
    {
        yield return new WaitForSeconds(35.0f);
        FPS.SetActive(true);
        Destroy(cinematicObject);
    }
}
