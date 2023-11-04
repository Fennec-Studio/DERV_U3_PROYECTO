using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundThemes : MonoBehaviour
{
    [SerializeField] AudioSource intro;
    [SerializeField] AudioSource loopSong;
    private bool introFinished = false;

    void Start()
    {
        loopSong.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(!intro.isPlaying && !introFinished)
        {
            introFinished = true;
            loopSong.Play();
        }
    }
}
