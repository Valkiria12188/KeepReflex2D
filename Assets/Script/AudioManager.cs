using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip pointSound;
    private AudioSource backgroundMusic;
    private AudioSource soundEffects;
    private void Awake()
    {
        backgroundMusic = transform.Find("BackgroundMusic").GetComponent<AudioSource>();
        soundEffects = transform.Find("SoundEffects").GetComponent<AudioSource>();
    }

    public void OnGameStart()
    {
        if (!backgroundMusic.isPlaying) backgroundMusic.Play();
        soundEffects.volume = 1;
        soundEffects.pitch = 1;
    }

    public void OnGameOver()
    {
        soundEffects.PlayOneShot(gameOverSound);
        if (!backgroundMusic.isPlaying) backgroundMusic.Play();
        backgroundMusic.volume = 0.6f;
        backgroundMusic.pitch = 0.7f;
    }

    public float GetVolume()
    {
        float[] samples = new float[1024];
        float sum = 0f;

        backgroundMusic.GetOutputData(samples, 0);

        foreach (var sample in samples)
        {
            sum += sample * sample;
        }
        return Mathf.Sqrt(sum / 1024);
    }

    public void OnPointEarned()
    {
        soundEffects.PlayOneShot(pointSound);
        if (!backgroundMusic.isPlaying) backgroundMusic.Play();
    }
}
