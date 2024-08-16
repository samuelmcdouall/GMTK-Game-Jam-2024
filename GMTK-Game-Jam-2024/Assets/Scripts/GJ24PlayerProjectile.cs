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

    void Start()
    {
        _projectileRB = GetComponent<Rigidbody>();
        _projectileRB.velocity = Vector3.down * _speed;
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
            }
            else if (_projectileType == ProjectileType.Shrink)
            {
                other.gameObject.GetComponent<GJ24SizeableObject>().ShrinkObject();
            }
        }
        else if (other.tag == "GrowObject")
        {
            if (_projectileType == ProjectileType.Grow)
            {
                other.gameObject.GetComponent<GJ24SizeableObject>().GrowObject();
            }
            if (_projectileType == ProjectileType.Shrink)
            {
                other.gameObject.GetComponent<GJ24SizeableObject>().ShrinkObject();
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
