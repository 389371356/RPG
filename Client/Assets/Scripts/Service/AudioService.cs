using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : Singleton<AudioService>
{
    private AudioSource _effectAudioSource;
    private AudioSource _bgmAudioSource;

    public override void InitSvc()
    {
        _effectAudioSource = gameObject.AddComponent<AudioSource>();
        _effectAudioSource.playOnAwake = false;
        _bgmAudioSource = gameObject.AddComponent<AudioSource>();
        _bgmAudioSource.loop = true;
        Debug.Log("Init AudioService...");
    }

    public void PlayBGM(AudioClip clip)
    {
        if (clip != null)
        {
            _bgmAudioSource.clip = clip;
            _bgmAudioSource.Play();
        }
    }
    public void PlayEffect(AudioClip clip)
    {
        if (clip != null)
        {
            _effectAudioSource.PlayOneShot(clip);
        }
    }
}
