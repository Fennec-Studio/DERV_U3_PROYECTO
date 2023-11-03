using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundThemes : MonoBehaviour
{
    [SerializeField] AudioSource intro;
    [SerializeField] AudioSource loopSong;
    void Start()
    {
        loopSong.Stop();
        StartCoroutine(PlayLoopSong());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PlayLoopSong()
    {
        yield return new WaitForSeconds(21.9f);
        loopSong.Play();
        //intro.Stop();
    }
}
