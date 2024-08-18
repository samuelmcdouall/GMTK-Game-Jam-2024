using System.Collections.Generic;
using UnityEngine;

public class GJ24SkyObjectsSpawner : MonoBehaviour // This is used on two separate instances for both spawning clouds in the environment and power ups
{
    [SerializeField]
    List<GameObject> _skyObjects;
    [SerializeField]
    float _minSpawnInterval;
    [SerializeField]
    float _maxSpawnInterval;
    [SerializeField]
    float _spawnIntervalTimer;
    private GJ24GameOverManager _gameOverManager;
    [SerializeField]
    float _lowestSpawnYValue;
    [SerializeField]
    float _highestSpawnYValue;

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
                SpawnRandomSkyObject();
            }
            else
            {
                _spawnIntervalTimer -= Time.deltaTime;
            }
        }
    }
    void SpawnRandomSkyObject()
    {
        _spawnIntervalTimer = Random.Range(_minSpawnInterval, _maxSpawnInterval);
        int rand = Random.Range(0, _skyObjects.Count);
        Vector3 startingPos = new Vector3(transform.position.x, Random.Range(_lowestSpawnYValue, _highestSpawnYValue), transform.position.z);
        Instantiate(_skyObjects[rand], startingPos, _skyObjects[rand].transform.rotation);
    }
}