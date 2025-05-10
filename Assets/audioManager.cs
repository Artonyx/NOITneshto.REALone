using System;
using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    [Header("Audio Clips")]
    public AudioClip bg;
    public AudioClip onHit;
    public AudioClip asteroidDeath;

    private void Start()
    {
        musicSource.clip = bg;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
