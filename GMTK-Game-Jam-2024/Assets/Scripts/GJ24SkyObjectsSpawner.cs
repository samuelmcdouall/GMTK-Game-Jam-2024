using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24SkyObjectsSpawner : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (!_gameOverManager.GameOver)
        {
            if (_spawnIntervalTimer < 0.0f)
            {
                _spawnIntervalTimer = Random.Range(_minSpawnInterval, _maxSpawnInterval);
                int rand = Random.Range(0, _skyObjects.Count);
                Vector3 startingPos = new Vector3(transform.position.x, Random.Range(_lowestSpawnYValue, _highestSpawnYValue), transform.position.z);
                Instantiate(_skyObjects[rand], startingPos, _skyObjects[rand].transform.rotation);
            }
            else
            {
                _spawnIntervalTimer -= Time.deltaTime;
            }
        }
    }
}
