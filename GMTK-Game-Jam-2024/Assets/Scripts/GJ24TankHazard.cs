using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24TankHazard : MonoBehaviour
{
    [SerializeField]
    float _speed;
    float _edgeOfViewableScreen = -200.0f;
    [SerializeField]
    float _shootInterval;
    float _shootIntervalTimer;
    [SerializeField]
    Transform _tankGun;
    [SerializeField]
    Transform _tankFirePoint;
    [SerializeField]
    GameObject _tankProjectile;
    // Start is called before the first frame update
    void Start()
    {
        _shootIntervalTimer = _shootInterval;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
        if (transform.position.x < _edgeOfViewableScreen)
        {
            Destroy(gameObject);
        }
        if (_shootIntervalTimer < 0.0f)
        {
            _shootIntervalTimer = _shootInterval;
            GameObject projectile = Instantiate(_tankProjectile, _tankFirePoint.position, Quaternion.identity);
            projectile.GetComponent<GJ24TankProjectile>().Direction = Quaternion.Euler(0.0f, 0.0f, 120.0f) * _tankGun.rotation.eulerAngles.normalized;
        }
        else
        {
            _shootIntervalTimer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("GAME OVER");
            Time.timeScale = 0.0f;
        }
    }
}
