using System.Collections.Generic;
using UnityEngine;

public class GJ24TreeSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _trees;
    [SerializeField]
    float _minSpawnInterval;
    [SerializeField]
    float _maxSpawnInterval;
    [SerializeField]
    float _spawnIntervalTimer;
    private GJ24GameOverManager _gameOverManager;
    [SerializeField]
    float _lowestSpawnZValue;
    [SerializeField]
    float _highestSpawnZValue;

    void Start()
    {
        _spawnIntervalTimer = Random.Range(_minSpawnInterval, _maxSpawnInterval);
        _gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GJ24GameOverManager>();
    }
    void Update()
    {
        if (!_gameOverManager.GameOver)
        {
            if (_spawnIntervalTimer < 0.0f)
            {
                _spawnIntervalTimer = Random.Range(_minSpawnInterval, _maxSpawnInterval);
                SpawnRandomTree();
            }
            else
            {
                _spawnIntervalTimer -= Time.deltaTime;
            }
        }
    }
    void SpawnRandomTree()
    {
        int rand = Random.Range(0, _trees.Count);
        Vector3 startingPos = new Vector3(transform.position.x, transform.position.y, Random.Range(_lowestSpawnZValue, _highestSpawnZValue));
        Instantiate(_trees[rand], startingPos, _trees[rand].transform.rotation);
    }
}