using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24Environment : MonoBehaviour
{
    [SerializeField]
    float _speed;
    float _edgeOfViewableScreen = -200.0f;
    private GJ24GameOverManager _gameOverManager;

    // Start is called before the first frame update
    void Start()
    {

        _gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GJ24GameOverManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameOverManager.GameOver)
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
            if (transform.position.x < _edgeOfViewableScreen)
            {
                Destroy(gameObject);
            }
        }
    }
}
