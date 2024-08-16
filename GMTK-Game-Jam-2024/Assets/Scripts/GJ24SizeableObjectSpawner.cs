using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24SizeableObjectSpawner : MonoBehaviour
{
    [SerializeField]
    float _spawnInterval;
    float _spawnIntervalTimer;

    [SerializeField]
    List<GameObject> _spawnableObjects;
    // Start is called before the first frame update
    void Start()
    {
        _spawnIntervalTimer = _spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawnIntervalTimer < 0.0f)
        {
            _spawnIntervalTimer = _spawnInterval;
            print("Attempt spawn!");
            int rand = Random.Range(0, _spawnableObjects.Count + 1); // This is to give spawning nothing an option
            if (rand <= _spawnableObjects.Count - 1)
            {
                Instantiate(_spawnableObjects[rand], transform.position, _spawnableObjects[rand].transform.rotation);
            }
        }
        else
        {
            _spawnIntervalTimer -= Time.deltaTime;
        }
    }
}
