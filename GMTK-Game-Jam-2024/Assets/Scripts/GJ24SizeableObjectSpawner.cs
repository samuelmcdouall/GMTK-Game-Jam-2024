using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        _spawnIntervalTimer = 0.0f;
        _gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GJ24GameOverManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameOverManager.GameOver)
        {
            if (_spawnIntervalTimer < 0.0f)
            {
                _spawnIntervalTimer = _spawnInterval;
                int rand = Random.Range(0, _spawnableObjects.Count + 1); // This is to give spawning nothing an option
                if (rand <= _spawnableObjects.Count - 1)
                {
                    if (rand == _spawnableObjects.Count - 1)// tank spawns
                    {
                        int tankRand = Random.Range(0, 3); // only 1/3 chance to spawn tank if chosen, otherwise do someting else
                        if (tankRand != 0)
                        {
                            rand -= Random.Range(1, _spawnableObjects.Count);
                        }
                    }
                    Instantiate(_spawnableObjects[rand], transform.position, _spawnableObjects[rand].transform.rotation);
                }
            }
            else
            {
                _spawnIntervalTimer -= Time.deltaTime;
            }
        }
    }
}
