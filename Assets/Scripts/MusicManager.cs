using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip music;


    // Get audio source
    public AudioSource AudioSourceMusic { get => audioSource; }

    private float lastMusic = -200;


    void Update()
    {
        if (lastMusic + 110f < Time.time)
        {
            PlayMusic(music, 0.6f);
            lastMusic = Time.time;
        }
    }

    // Play a given music
    public void PlayMusic(AudioClip clip, float volume = 0.5f)
    {
        audioSource.PlayOneShot(clip, volume);
    }
}

