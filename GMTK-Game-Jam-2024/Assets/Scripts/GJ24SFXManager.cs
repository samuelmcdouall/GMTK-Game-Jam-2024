using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24SFXManager : MonoBehaviour
{
    [SerializeField]
    AudioSource _playerFireAS;
    [SerializeField]
    AudioClip _playerFireClip;
    
    public void PlaySound(AudioClip clip, float pitch)
    {
        _playerFireAS.pitch = pitch;
        _playerFireAS.PlayOneShot(clip, 0.5f);
    }
}
