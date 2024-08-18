using UnityEngine;

public class GJ24Environment : MonoBehaviour
{
    [SerializeField]
    float _speed;
    float _edgeOfViewableScreen = -200.0f;
    private GJ24GameOverManager _gameOverManager;

    void Start()
    {
        _gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GJ24GameOverManager>();
    }
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