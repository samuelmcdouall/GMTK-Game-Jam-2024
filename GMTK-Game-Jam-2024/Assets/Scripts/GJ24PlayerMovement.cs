using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float _playerSpeed;
    [SerializeField]
    float _lowerXPosLimit;
    [SerializeField]
    float _upperXPosLimit;
    [SerializeField]
    float _lowerYPosLimit;
    [SerializeField]
    float _upperYPosLimit;
    public bool ShieldOn;
    [SerializeField]
    GameObject _shieldFX;
    float _shieldTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = GetInput();
        direction = LimitDirectionIfAtEdges(direction);
        transform.position += direction.normalized * Time.deltaTime * _playerSpeed;

        if (ShieldOn)
        {
            if (_shieldTimer < 0.0f)
            {
                ShieldOn = false;
                _shieldFX.SetActive(false);
            }
            else
            {
                _shieldTimer -= Time.deltaTime;
            }
        }


    }

    Vector3 LimitDirectionIfAtEdges(Vector3 direction)
    {
        if (transform.position.x < _lowerXPosLimit && direction.x < 0.0f)
        {
            direction = new Vector3(0.0f, direction.y, 0.0f);
        }
        if (transform.position.x > _upperXPosLimit && direction.x > 0.0f)
        {
            direction = new Vector3(0.0f, direction.y, 0.0f);
        }
        if (transform.position.y < _lowerYPosLimit && direction.y < 0.0f)
        {
            direction = new Vector3(direction.x, 0.0f, 0.0f);
        }
        if (transform.position.y > _upperYPosLimit && direction.y > 0.0f)
        {
            direction = new Vector3(direction.x, 0.0f, 0.0f);
        }

        return direction;
    }

    Vector3 GetInput()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += new Vector3(0.0f, 1.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += new Vector3(-1.0f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += new Vector3(0.0f, -1.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += new Vector3(1.0f, 0.0f, 0.0f);
        }

        return direction;
    }

    public void ShieldOnForSeconds(float time)
    {
        _shieldFX.SetActive(true);
        _shieldTimer = time;
        ShieldOn = true;
    }
}
