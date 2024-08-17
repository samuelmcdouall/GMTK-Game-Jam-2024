using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24TankProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody _projectileRB;
    [SerializeField]
    float _speed;
    [System.NonSerialized]
    public Vector3 Direction;
    private GJ24GameOverManager _gameOverManager;

    void Start()
    {
        _projectileRB = GetComponent<Rigidbody>();
        _projectileRB.velocity = Direction * _speed;
        _gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GJ24GameOverManager>();
        Destroy(gameObject, 20.0f); // so not floating on forever
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _gameOverManager.TriggerGameOver(true);
            Destroy(gameObject);
        }
    }
}
