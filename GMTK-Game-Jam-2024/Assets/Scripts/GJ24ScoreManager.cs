using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GJ24ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _numShrunkObjectsText;
    [SerializeField] TMP_Text _numGrownObjectsText;
    public int Score;
    [SerializeField] int _numShrunkObjects;
    [SerializeField] int _numGrownObjects;
    [SerializeField]
    GJ24LevelManager _levelManager;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int score, bool shrunkObject)
    {
        Score += score;
        if (shrunkObject)
        {
            _numShrunkObjects++;
        }
        else
        {
            _numGrownObjects++;
        }
        UpdateText();
    }
    void UpdateText()
    {
        _scoreText.text = $"Score: {Score} / {_levelManager.RequiredScore}";
        _numShrunkObjectsText.text = "Shrunk objects: " + _numShrunkObjects;
        _numGrownObjectsText.text = "Grown objects: " + _numGrownObjects;
    }
}
