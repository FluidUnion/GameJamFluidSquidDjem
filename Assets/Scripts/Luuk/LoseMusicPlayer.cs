using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            //if menu/main music is playing stop it
            //
            audioSource.Play();
        }
    }
}
