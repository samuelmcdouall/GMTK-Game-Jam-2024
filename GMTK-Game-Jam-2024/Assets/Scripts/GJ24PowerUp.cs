using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GJ24PowerUp : MonoBehaviour
{
    [SerializeField]
    PowerUpType _powerUpType;
    [SerializeField]
    float _speed;
    float _edgeOfViewableScreen = -200.0f;
    GJ24GameOverManager _gameOverManager;
    GJ24LevelManager _levelManager;
    GJ24SFXManager _sfxManager;
    [SerializeField]
    AudioClip _powerupSound;

    // Start is called before the first frame update
    void Start()
    {
        _levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<GJ24LevelManager>();
        _gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GJ24GameOverManager>();
        _sfxManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GJ24SFXManager>();
    }

    // Update is called once per frame
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _sfxManager.PlaySound(_powerupSound, 1.0f);
            if (_powerUpType == PowerUpType.TimeIncrease)
            {
                _levelManager.AddTime(10.0f);
            }
            else if (_powerUpType == PowerUpType.Shield)
            {
                other.gameObject.GetComponent<GJ24PlayerMovement>().ShieldOnForSeconds(10.0f);
            }
            Destroy(gameObject);
        }
    }

    enum PowerUpType
    {
        TimeIncrease,
        Shield
    }
}
