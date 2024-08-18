using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24Rotate : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 60.0f)]
    float revolution_time;
    [SerializeField]
    Direction _setDirection;
    Vector3 _directionVector;
    [SerializeField]
    bool _invertDirection;

    void Start()
    {
        if (_setDirection == Direction.X)
        {
            _directionVector = Vector3.right;
        }
        else if (_setDirection == Direction.Y)
        {
            _directionVector = Vector3.up;
        }
        else if (_setDirection == Direction.Z)
        {
            _directionVector = Vector3.forward;
        }
        if (_invertDirection)
        {
            _directionVector = -_directionVector;
        }
    }

    void Update()
    {
        transform.Rotate(_directionVector, Time.deltaTime * 360.0f / revolution_time);
    }

    enum Direction
    {
        X,
        Y,
        Z
    }
}
