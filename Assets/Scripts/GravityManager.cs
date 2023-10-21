using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    [SerializeField] float sceneGravity = 9.81f; 
    void Awake()
    {
        Physics.gravity = new Vector3(0, sceneGravity, 0);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
