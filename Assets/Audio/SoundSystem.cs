using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [System.Serializable]
    public class SoundLibrary
    {
        public AudioClip clickButton, lose,backgound, upgradePlayer;
    }
    public static SoundSystem instance;
    
    public SoundLibrary soundLibrary;
    [SerializeField] private Sound soundPrefab;
    [SerializeField] private AudioSource backgroundAudioSource;
    public bool isAudioPlay;
    public bool IsADV;
    public void Init()
    {
        InitSingleton();
    }
    private void InitSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            isAudioPlay = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetActiveSound(bool active)
    {
        isAudioPlay = active;
        if(isAudioPlay == false)
        {
            backgroundAudioSource.Stop();
        }
        else
        {
            backgroundAudioSource.Play();
        }
    }
    public void CreateSound(AudioClip audioClip)
    {
        if (isAudioPlay)
        {
            var sound = Instantiate(soundPrefab, transform);
            sound.PlaySound(audioClip);
        }

    }
    public void CreateSound(AudioClip audioClip, float startTime,float volume)
    {
        if (isAudioPlay)
        {
            var sound = Instantiate(soundPrefab, transform);

            sound.AudioSource.clip = audioClip;
            sound.AudioSource.volume = volume;
            int startSample = (int)(startTime * audioClip.frequency);
            sound.AudioSource.timeSamples = startSample;
            //audioSource.Play();

            sound.PlaySound(sound.AudioSource.clip);
        }

    }
    public void CreateSound(AudioClip audioClip, float startTime)
    {
        if (isAudioPlay)
        {
            var sound = Instantiate(soundPrefab, transform);

            sound.AudioSource.clip = audioClip;
            int startSample = (int)(startTime * audioClip.frequency);
            sound.AudioSource.timeSamples = startSample;
            //audioSource.Play();

            sound.PlaySound(sound.AudioSource.clip);
        }

    }
    public void OnApplicationPause(bool pause)
    {
        if (IsADV) return; 
        if(pause)
        {
            SetActiveSound(false);
        }
        else
        {
            SetActiveSound(true);
        }
    }
    public void OnApplicationFocus(bool focus)
    {
        if (IsADV) return;
        if (focus == false)
        {
            SetActiveSound(false);
        }
        else
        {
            SetActiveSound(true);
        } 
    }
   
}
