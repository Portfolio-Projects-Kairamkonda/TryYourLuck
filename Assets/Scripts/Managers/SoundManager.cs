using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip _selectedAudioClip;
    [SerializeField]
    private AudioClip _guessConfirmationClip;
    [SerializeField]
    private AudioClip _mainButtonClip;



    private ILogger debug;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void OnEnable()
    {
        EventManager.onCardSelected += PlaySelectedCardAudio;
        EventManager.onRestartGame += GuessCardAudio;
    }

    private void OnDisable()
    {
        EventManager.onCardSelected -= PlaySelectedCardAudio;
        EventManager.onRestartGame -= GuessCardAudio;
    }

    private void Start()
    {
        debug = new NoLogging();
        AudioSettings();
    }

    private void PlaySelectedCardAudio()
    {
        debug.Log("Played selected card audio");
        // Uncomment after adding audio clip
        audioSource.clip = _selectedAudioClip;
        audioSource.Play();
    }
    private void GuessCardAudio()
    {
        debug.Log("Guessed selected card audio");
        // Uncomment after adding audio clip
        audioSource.clip = _guessConfirmationClip;
        audioSource.Play();
    }


    public void PlayMainButtonAudio()
    {
        audioSource.clip = _mainButtonClip;
        audioSource.Play();
    }
    private void AudioSettings()
    {
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

}
