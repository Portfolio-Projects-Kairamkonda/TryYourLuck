using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip _selectedAudioClip;

    private ILogger debug;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void OnEnable()
    {
        EventManager.onSelectedCardEffects += PlaySelectedCardAudio;    
    }

    private void OnDisable()
    {
        EventManager.onSelectedCardEffects -= PlaySelectedCardAudio;
    }

    private void Start()
    {
        debug = new NoLogging();
        AudioSettings();
    }

    private void PlaySelectedCardAudio()
    {
        debug.Log("Played selected card audio");
        /* Uncomment after adding audio clip
        audioSource.clip = _selectedAudioClip;
        audioSource.Play();
        */
    }

    private void AudioSettings()
    {
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

}
