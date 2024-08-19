using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_bgm : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        //if main music is playing stop it
        //
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    public void PauseMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

}
