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

    void Start()
    {
        _projectileRB = GetComponent<Rigidbody>();
        _projectileRB.velocity = Direction * _speed;
        Destroy(gameObject, 20.0f); // so not floating on forever
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0.0f;
            Destroy(gameObject);
        }
    }
}
