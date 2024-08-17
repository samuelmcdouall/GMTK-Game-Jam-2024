using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GJ24ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _numShrunkObjectsText;
    [SerializeField] TMP_Text _numGrownObjectsText;
    [SerializeField] int _score;
    [SerializeField] int _numShrunkObjects;
    [SerializeField] int _numGrownObjects;

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
        _score += score;
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
        _scoreText.text = "Score: " + _score;
        _numShrunkObjectsText.text = "Shrunk objects: " + _numShrunkObjects;
        _numGrownObjectsText.text = "Grown objects: " + _numGrownObjects;
    }
}
