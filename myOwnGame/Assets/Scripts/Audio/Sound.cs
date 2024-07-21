using System;
using UnityEngine;

[CreateAssetMenu(fileName ="Song", menuName = "ScriptableObjects/Song", order = 2)]
public class Sound : ScriptableObject
{
    public string nameSound;

    [Range(0f,1f)]
    public float volume = 0.5f;
    [Range(0.5f,1.5f)]
    public float pitch = 1f;

    public bool loop = false;

    public AudioClip clip;
    public AudioSource audioSource;

    public void SetSource(AudioSource source)
    {
        audioSource= source;
        audioSource.clip = clip;
        source.loop = loop;
    }

    public void Play()
    {
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.Play();
    }
    public void Stop()
    {
        audioSource.Stop();
    }
}
