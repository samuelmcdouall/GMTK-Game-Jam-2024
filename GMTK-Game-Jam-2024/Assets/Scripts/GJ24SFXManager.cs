using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24SFXManager : MonoBehaviour
{
    [SerializeField]
    AudioSource _playerFireAS;
    [SerializeField]
    AudioClip _playerFireClip;
    public AudioSource MusicAS;
    [SerializeField]
    List<AudioClip> _musicTracks;
    public float SFXVolume;

    void Start()
    {
        MusicAS.clip = _musicTracks[Random.Range(0, _musicTracks.Count)];
        MusicAS.Play();
    }

    public void PlaySound(AudioClip clip, float pitch)
    {
        _playerFireAS.pitch = pitch;
        _playerFireAS.PlayOneShot(clip, SFXVolume);
    }
}
