using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24FlyingHazardSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject _biPlane;
    [SerializeField]
    GameObject _jetPlane;
    [SerializeField]
    GameObject _helicopter;
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
                int rand = Random.Range(0, 6);
                Vector3 startingPos = new Vector3(transform.position.x, Random.Range(_lowestSpawnYValue, _highestSpawnYValue), transform.position.z);
                if (rand == 0) // Lower chance to spawn jetplane as its harder to avoid
                {
                    Instantiate(_jetPlane, startingPos, _jetPlane.transform.rotation);
                }
                else if (rand <= 2)
                {
                    Instantiate(_biPlane, startingPos, _biPlane.transform.rotation);
                }
                else
                {
                    Instantiate(_helicopter, startingPos, _helicopter.transform.rotation);
                }
            }
            else
            {
                _spawnIntervalTimer -= Time.deltaTime;
            }
        }
    }
}
