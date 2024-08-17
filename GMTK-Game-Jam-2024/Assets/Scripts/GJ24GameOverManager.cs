using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GJ24GameOverManager : MonoBehaviour
{
    public bool GameOver;
    [SerializeField] GameObject _explosionFX;
    [SerializeField] AudioClip _explosionSFX;
    [SerializeField] GameObject _player;
    [SerializeField] GJ24SFXManager _sfxManager;
    [SerializeField] GameObject _gameOverScreen;
    [SerializeField] TMP_Text _gameOverText;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerGameOver(bool destroyed) // false = ran out of time
    {
        if (!GameOver)
        {
            print("GAME OVER");
            GameOver = true;
            Instantiate(_explosionFX, _player.transform.position, Quaternion.identity);
            _sfxManager.PlaySound(_explosionSFX, 1.0f);
            _sfxManager.MusicAS.Stop();
            string reason = "X";
            if (destroyed)
            {
                reason = "You were destroyed";
            }
            else
            {
                reason = "You ran out of time";
            }
            _gameOverText.text = $"{reason}\n\nTry Again?";
            Invoke("ShowGameOverScreen", 2.0f);
            Destroy(_player);
        }
    }

    void ShowGameOverScreen()
    {
        _gameOverScreen.SetActive(true);
    }

    public void QuitButton()
    {
        // Quit to menu here
    }
    public void TryAgainButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
