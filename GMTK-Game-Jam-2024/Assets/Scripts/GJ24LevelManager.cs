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
    public TMP_Text CurrentLevelText;
    //[SerializeField]
    //TMP_Text _requiredScoreText;
    public TMP_Text TimerText;
    public TMP_Text LevelIntroText;
    public bool NewLevelShowing;
    [SerializeField]
    float _newLevelShowingInterval;
    float _newLevelShowingTimer;
    [SerializeField]
    GJ24ScoreManager _scoreManager;
    [SerializeField]
    GJ24GameOverManager _gameOverManager;
    int _oldTime;



    void Start()
    {
        _currentLevelTimer = _currentLevelDuration;
        _oldTime = (int)_currentLevelDuration;
        NewLevelShowing = true;
        _newLevelShowingTimer = _newLevelShowingInterval;
        LevelIntroText.text = $"Level {CurrentLevel} \nShrink/Grow quota: {RequiredScore}";
        LevelIntroText.gameObject.SetActive(true);
        CurrentLevelText.gameObject.SetActive(false);
        //_requiredScoreText.gameObject.SetActive(false);
        TimerText.gameObject.SetActive(false);
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
                    LevelIntroText.gameObject.SetActive(false);
                    CurrentLevelText.gameObject.SetActive(true);
                    CurrentLevelText.text = $"Level {CurrentLevel}";
                    //_requiredScoreText.gameObject.SetActive(true);
                    //_requiredScoreText.text = $"/ {RequiredScore}";
                    TimerText.gameObject.SetActive(true);
                    TimerText.text = $"Time left: {(int)_currentLevelTimer}";
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
                        _oldTime = (int)_currentLevelDuration;
                        LevelIntroText.gameObject.SetActive(true);
                        CurrentLevel++;
                        if (RequiredScore <= 400)
                        {
                            RequiredScore += 100;
                        }
                        else if (RequiredScore <= 1250)
                        {
                            RequiredScore += 250;
                        }
                        else
                        {
                            RequiredScore += 500;
                        }
                        LevelIntroText.text = $"Level {CurrentLevel} \nShrink/Grow Quota: {RequiredScore}";
                        _scoreManager.UpdateText();
                        CurrentLevelText.gameObject.SetActive(false);
                        //_requiredScoreText.gameObject.SetActive(false);
                        TimerText.gameObject.SetActive(false);
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
                    if (_oldTime != (int)_currentLevelTimer) // only show the second when updated, so not updating every frame
                    {
                        _oldTime = (int)_currentLevelTimer;
                        TimerText.text = $"Time left: {(int)_currentLevelTimer}";
                    }
                }
            }
        }
    }

    public void AddTime(float time)
    {
        _currentLevelTimer += time;
        TimerText.text = $"Time left: {(int)_currentLevelTimer}";
    }
}
