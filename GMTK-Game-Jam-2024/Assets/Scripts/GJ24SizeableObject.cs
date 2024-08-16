using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24SizeableObject : MonoBehaviour
{
    [SerializeField]
    Transform _bottomPoint;
    float _groundLevel;
    [SerializeField]
    float _speed;
    float _edgeOfViewableScreen = -200.0f;
    // Start is called before the first frame update
    void Start()
    {
        _groundLevel = GameObject.FindGameObjectWithTag("GroundLevel").transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
        if (Mathf.Abs(_bottomPoint.transform.position.y - _groundLevel) > 0.1f)
        {
            transform.position += new Vector3(0.0f, _groundLevel - _bottomPoint.transform.position.y, 0.0f);
        }
        if (transform.position.x < _edgeOfViewableScreen)
        {
            Destroy(gameObject);
        }
    }

    public void GrowObject()
    {
        transform.localScale *= 2.0f;
    }
    public void ShrinkObject()
    {
        transform.localScale /= 2.0f;
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
