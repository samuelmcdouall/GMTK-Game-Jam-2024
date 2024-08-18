using System.Collections.Generic;
using UnityEngine;

public class GJ24SizeableObjectSpawner : MonoBehaviour
{
    [SerializeField]
    float _spawnInterval;
    float _spawnIntervalTimer;
    private GJ24GameOverManager _gameOverManager;
    [SerializeField]
    List<GameObject> _spawnableObjects;
    [SerializeField]
    GJ24LevelManager _levelManager;

    void Start()
    {
        _spawnIntervalTimer = 0.0f;
        _gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GJ24GameOverManager>();
    }
    void Update()
    {
        if (!_gameOverManager.GameOver && !_levelManager.NewLevelShowing)
        {
            if (_spawnIntervalTimer < 0.0f)
            {
                _spawnIntervalTimer = _spawnInterval;
                SpawnRandomSizeableObject();
            }
            else
            {
                _spawnIntervalTimer -= Time.deltaTime;
            }
        }
    }
    void SpawnRandomSizeableObject()
    {
        int rand = Random.Range(0, _spawnableObjects.Count + 1); // +1 is to give spawning nothing an option
        if (rand <= _spawnableObjects.Count - 1) // Final object in the list is a tank which we want to reduce the rate of spawning in the first couple of levels
        {
            if (rand == _spawnableObjects.Count - 1 && _levelManager.CurrentLevel <= 2)
            {
                int tankRand = Random.Range(0, 4 - _levelManager.CurrentLevel); // Only 1/3 chance on level 1, 1/2 level 2, 100% level 3 onwards to spawn tank if chosen, otherwise spawn someting else
                if (tankRand > 0)
                {
                    rand -= Random.Range(1, _spawnableObjects.Count);
                }
            }
            Instantiate(_spawnableObjects[rand], transform.position, _spawnableObjects[rand].transform.rotation);
        }
    }
}