using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_bgm : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        PlayMusic();
    }

    public void PlayMusic()
    {
        //if menu music is playing stop it
        //
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    public void PauseMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
    public void ResumeMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.UnPause();
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
