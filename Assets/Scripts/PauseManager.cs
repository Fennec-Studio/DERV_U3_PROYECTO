using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private bool isPaused;
    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(isPaused);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            pauseMenu.SetActive(isPaused);

            Time.timeScale = isPaused ? 0 : 1;
        }
    }
}
