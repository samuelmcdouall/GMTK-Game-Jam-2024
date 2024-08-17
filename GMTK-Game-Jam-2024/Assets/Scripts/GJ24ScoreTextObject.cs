using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24ScoreTextObject : MonoBehaviour
{
    [SerializeField]
    float _speed;
    [SerializeField]
    float _lifetime;
    float _edgeOfViewableScreen = -200.0f;
    private GJ24GameOverManager _gameOverManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GJ24GameOverManager>();
        Destroy(gameObject, _lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameOverManager.GameOver)
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
    }
}
