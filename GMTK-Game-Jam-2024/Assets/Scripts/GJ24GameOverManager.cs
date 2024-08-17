using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24GameOverManager : MonoBehaviour
{
    public bool GameOver;
    [SerializeField] GameObject _explosionFX;
    [SerializeField] AudioClip _explosionSFX;
    [SerializeField] GameObject _player;
    [SerializeField] GJ24SFXManager _sfxManager;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerGameOver()
    {
        print("GAME OVER");
        GameOver = true;
        Instantiate(_explosionFX, _player.transform.position, Quaternion.identity);
        _sfxManager.PlaySound(_explosionSFX, 1.0f);
        _sfxManager.MusicAS.Stop();
        Destroy(_player);
    }
}
