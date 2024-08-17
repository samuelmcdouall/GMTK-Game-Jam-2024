using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GJ24LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int CurrentLevel;
    public int RequiredScore; // Progress by 100, 200, 300, 400, 500, then +250 onwards
    [SerializeField]
    float _currentLevelDuration;
    [SerializeField]
    float _currentLevelTimer;
    [SerializeField]
    TMP_Text _currentLevelText;
    //[SerializeField]
    //TMP_Text _requiredScoreText;
    [SerializeField]
    TMP_Text _timerText;
    [SerializeField]
    TMP_Text _levelIntroText;
    public bool NewLevelShowing;
    [SerializeField]
    float _newLevelShowingInterval;
    float _newLevelShowingTimer;
    [SerializeField]
    GJ24ScoreManager _scoreManager;
    [SerializeField]
    GJ24GameOverManager _gameOverManager;



    void Start()
    {
        _currentLevelTimer = _currentLevelDuration;
        NewLevelShowing = true;
        _newLevelShowingTimer = _newLevelShowingInterval;
        _levelIntroText.text = $"Level {CurrentLevel} \nScore Needed: {RequiredScore}";
        _levelIntroText.gameObject.SetActive(true);
        _currentLevelText.gameObject.SetActive(false);
        //_requiredScoreText.gameObject.SetActive(false);
        _timerText.gameObject.SetActive(false);
        // Show new level text with details
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameOverManager.GameOver)
        {
            // Introducing new level
            if (NewLevelShowing)
            {
                if (_newLevelShowingTimer < 0.0f)
                {
                    NewLevelShowing = false;
                    _newLevelShowingTimer = _newLevelShowingInterval;
                    _levelIntroText.gameObject.SetActive(false);
                    _currentLevelText.gameObject.SetActive(true);
                    _currentLevelText.text = $"Level {CurrentLevel}";
                    //_requiredScoreText.gameObject.SetActive(true);
                    //_requiredScoreText.text = $"/ {RequiredScore}";
                    _timerText.gameObject.SetActive(true);
                    _timerText.text = $"Time left: {(int)_currentLevelTimer}";
                }
                else
                {
                    _newLevelShowingTimer -= Time.deltaTime;
                }
            }
            // Main gameplay loop
            else
            {
                if (_currentLevelTimer < 0.0f)
                {
                    if (_scoreManager.Score >= RequiredScore)
                    {
                        NewLevelShowing = true;
                        _currentLevelTimer = _currentLevelDuration;
                        _levelIntroText.gameObject.SetActive(true);
                        CurrentLevel++;
                        if (RequiredScore <= 400)
                        {
                            RequiredScore += 100;
                        }
                        else
                        {
                            RequiredScore += 250;
                        }
                        _levelIntroText.text = $"Level {CurrentLevel} \nScore Needed: {RequiredScore}";
                        _currentLevelText.gameObject.SetActive(false);
                        //_requiredScoreText.gameObject.SetActive(false);
                        _timerText.gameObject.SetActive(false);
                    }
                    else
                    {
                        print("NOT ENOUGH POINTS");
                        _gameOverManager.TriggerGameOver(false);

                    }
                }
                else
                {
                    _currentLevelTimer -= Time.deltaTime;
                    _timerText.text = $"Time left: {(int)_currentLevelTimer}";
                }
            }
        }
    }
}
