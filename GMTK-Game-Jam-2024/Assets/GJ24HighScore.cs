using TMPro;
using UnityEngine;

public class GJ24HighScore : MonoBehaviour
{
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        string scoreString = "-";
        if (highScore > 0)
        {
            scoreString = "" + highScore;
        }
        GetComponent<TMP_Text>().text = $"High Score: {scoreString}";
    }
}