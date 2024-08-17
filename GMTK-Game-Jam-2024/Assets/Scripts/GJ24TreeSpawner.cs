using System.Collections;
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
    [SerializeField]
    float _lowestSpawnZValue;
    [SerializeField]
    float _highestSpawnZValue;

    void Start()
    {
        _spawnIntervalTimer = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawnIntervalTimer < 0.0f)
        {
            _spawnIntervalTimer = Random.Range(_minSpawnInterval, _maxSpawnInterval);
            int rand = Random.Range(0, _trees.Count);
            Vector3 startingPos = new Vector3(transform.position.x, transform.position.y, Random.Range(_lowestSpawnZValue, _highestSpawnZValue));
            Instantiate(_trees[rand], startingPos, _trees[rand].transform.rotation);
        }
        else
        {
            _spawnIntervalTimer -= Time.deltaTime;
        }
    }
}
