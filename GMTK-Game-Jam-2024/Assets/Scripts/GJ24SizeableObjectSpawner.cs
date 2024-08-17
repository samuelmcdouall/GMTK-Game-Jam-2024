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
    [SerializeField]
    GJ24LevelManager _levelManager;
    // Start is called before the first frame update
    void Start()
    {
        _spawnIntervalTimer = 0.0f;
        _gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GJ24GameOverManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameOverManager.GameOver && !_levelManager.NewLevelShowing)
        {
            if (_spawnIntervalTimer < 0.0f)
            {
                _spawnIntervalTimer = _spawnInterval;
                int rand = Random.Range(0, _spawnableObjects.Count + 1); // This is to give spawning nothing an option
                //rand = 12;
                if (rand <= _spawnableObjects.Count - 1)
                {
                    if (rand == _spawnableObjects.Count - 1 && _levelManager.CurrentLevel <= 2)// tank spawns
                    {
                        int tankRand = Random.Range(0, 4 - _levelManager.CurrentLevel); // only 1/3 chance on level 1, 1/2 level 2, 100% level 3 onwards to spawn tank if chosen, otherwise spawn someting else
                        if (tankRand > 0)
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
