using UnityEngine;

public class GJ24TankProjectile : MonoBehaviour
{
    Rigidbody _projectileRB;
    [SerializeField]
    float _speed;
    [System.NonSerialized]
    public Vector3 Direction;
    GJ24GameOverManager _gameOverManager;

    void Start()
    {
        _projectileRB = GetComponent<Rigidbody>();
        _projectileRB.velocity = Direction * _speed;
        _gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GJ24GameOverManager>();
        Destroy(gameObject, 20.0f); // So not floating on forever
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !other.gameObject.GetComponent<GJ24PlayerMovement>().ShieldOn)
        {
            _gameOverManager.TriggerGameOver(true);
            Destroy(gameObject);
        }
    }
}
