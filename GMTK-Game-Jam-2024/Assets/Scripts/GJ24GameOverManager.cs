using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GJ24GameOverManager : MonoBehaviour
{
    public bool GameOver;
    [SerializeField]
    GameObject _explosionFX;
    [SerializeField]
    AudioClip _explosionSFX;
    [SerializeField]
    GameObject _player;
    [SerializeField]
    GJ24SFXManager _sfxManager;
    [SerializeField]
    GameObject _gameOverScreen;
    [SerializeField]
    TMP_Text _gameOverText;
    [SerializeField]
    GJ24LevelManager _levelManager;
    [SerializeField]
    GJ24ScoreManager _scoreManager;

    public void TriggerGameOver(bool destroyed) // false = ran out of time
    {
        if (!GameOver)
        {
            print("GAME OVER");
            GameOver = true;
            DisableUI();
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
            _gameOverText.text = $"{reason}" +
                $"\n\n<color=#FF6400>Level: {_levelManager.CurrentLevel}</color>" +
                $"\n<color=#A100FF>Score: {_scoreManager.Score}</color>" +
                $"\n<color=#FF0000>Shrunk Objects: {_scoreManager.NumShrunkObjects}</color>" +
                $"\n<color=#0000FF>Grown Objects: {_scoreManager.NumGrownObjects}</color>" +
                $"\n\nTry Again?";
            Invoke("ShowGameOverScreen", 2.0f);
            Destroy(_player);
        }
    }
    void DisableUI()
    {
        _levelManager.LevelIntroText.gameObject.SetActive(false);
        _levelManager.CurrentLevelText.gameObject.SetActive(false);
        _levelManager.TimerText.gameObject.SetActive(false);
        _scoreManager.ScoreText.gameObject.SetActive(false);
        _scoreManager.NumShrunkObjectsText.gameObject.SetActive(false);
        _scoreManager.NumGrownObjectsText.gameObject.SetActive(false);
    }
    void ShowGameOverScreen()
    {
        _gameOverScreen.SetActive(true);
    }
    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void TryAgainButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}