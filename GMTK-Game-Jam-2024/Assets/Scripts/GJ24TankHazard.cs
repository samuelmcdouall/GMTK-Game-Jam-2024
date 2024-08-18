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
    GJ24GameOverManager _gameOverManager;

    void Start()
    {
        _shootIntervalTimer = _shootInterval;
        _gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GJ24GameOverManager>();
    }
    void Update()
    {
        if (!_gameOverManager.GameOver)
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
            if (transform.position.x < _edgeOfViewableScreen)
            {
                Destroy(gameObject);
            }
            if (_shootIntervalTimer < 0.0f)
            {
                _shootIntervalTimer = _shootInterval;
                FireTankProjectile();
            }
            else
            {
                _shootIntervalTimer -= Time.deltaTime;
            }
        }
    }
    void FireTankProjectile()
    {
        GameObject projectile = Instantiate(_tankProjectile, _tankFirePoint.position, Quaternion.identity);
        projectile.GetComponent<GJ24TankProjectile>().Direction = Quaternion.Euler(0.0f, 0.0f, 120.0f) * _tankGun.rotation.eulerAngles.normalized;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !other.gameObject.GetComponent<GJ24PlayerMovement>().ShieldOn)
        {
            _gameOverManager.TriggerGameOver(true);
        }
    }
}