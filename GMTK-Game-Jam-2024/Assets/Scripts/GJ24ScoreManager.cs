using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GJ24ScoreManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text NumShrunkObjectsText;
    public TMP_Text NumGrownObjectsText;
    public int Score;
    public int NumShrunkObjects;
    public int NumGrownObjects;
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
            NumShrunkObjects++;
        }
        else
        {
            NumGrownObjects++;
        }
        UpdateText();
    }
    public void UpdateText()
    {
        ScoreText.text = $"Score: {Score} / {_levelManager.RequiredScore}";
        NumShrunkObjectsText.text = "Shrunk objects: " + NumShrunkObjects;
        NumGrownObjectsText.text = "Grown objects: " + NumGrownObjects;
    }
}
