using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24PlayerProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody _projectileRB;
    [SerializeField]
    float _speed;
    [SerializeField]
    ProjectileType _projectileType;
    [SerializeField]
    AudioClip _collideClip;
    GJ24SFXManager _sfxManager;

    void Start()
    {
        _projectileRB = GetComponent<Rigidbody>();
        _projectileRB.velocity = Vector3.down * _speed;
        _sfxManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GJ24SFXManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            return;
        }
        else if (other.tag == "ShrinkObject")
        {
            if (_projectileType == ProjectileType.Grow)
            {
                other.gameObject.GetComponent<GJ24SizeableObject>().GrowObject();
                _sfxManager.PlaySound(_collideClip, 0.8f);
            }
            else if (_projectileType == ProjectileType.Shrink)
            {
                other.gameObject.GetComponent<GJ24SizeableObject>().ShrinkObject();
                _sfxManager.PlaySound(_collideClip, 1.2f);
            }
        }
        else if (other.tag == "GrowObject")
        {
            if (_projectileType == ProjectileType.Grow)
            {
                other.gameObject.GetComponent<GJ24SizeableObject>().GrowObject();
                _sfxManager.PlaySound(_collideClip, 0.8f);
            }
            if (_projectileType == ProjectileType.Shrink)
            {
                other.gameObject.GetComponent<GJ24SizeableObject>().ShrinkObject();
                _sfxManager.PlaySound(_collideClip, 1.2f);
            }
        }
        Destroy(gameObject);
    }

    enum ProjectileType
    {
        Shrink,
        Grow,
        ShrinkGrow
    }
}
