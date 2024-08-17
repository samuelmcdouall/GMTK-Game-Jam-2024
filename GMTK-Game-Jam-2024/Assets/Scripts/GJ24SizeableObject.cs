using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24SizeableObject : MonoBehaviour
{
    [SerializeField]
    Transform _bottomPoint;
    float _groundLevel;
    public float Speed;
    [System.NonSerialized] public float EdgeOfViewableScreen = -200.0f;
    public int TargetSizeStep;
    public int CurrentSizeStep;
    public int ScoreValue;

    GJ24ScoreManager _scoreManager;
    GJ24GameOverManager _gameOverManager;

    Outline _outline;
    // Start is called before the first frame update
    void Start()
    {
        _groundLevel = GameObject.FindGameObjectWithTag("GroundLevel").transform.position.y;
        _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<GJ24ScoreManager>();
        _gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GJ24GameOverManager>();
        _outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (!_gameOverManager.GameOver)
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
            if (Mathf.Abs(_bottomPoint.transform.position.y - _groundLevel) > 0.1f)
            {
                transform.position += new Vector3(0.0f, _groundLevel - _bottomPoint.transform.position.y, 0.0f);
            }
            if (transform.position.x < EdgeOfViewableScreen)
            {
                Destroy(gameObject);
            }
        }
    }

    public void GrowObject()
    {
        transform.localScale *= 2.0f;
        CurrentSizeStep++;

        if (CurrentSizeStep >= TargetSizeStep && gameObject.tag == "GrowObject") 
        {
            if (_outline)
            {
                _outline.OutlineColor = Color.green;
            }
            _scoreManager.IncreaseScore(ScoreValue, false);
        }
    }
    public void ShrinkObject()
    {
        transform.localScale /= 2.0f;
        CurrentSizeStep--;
        if (CurrentSizeStep <= TargetSizeStep && gameObject.tag == "ShrinkObject")
        {
            if (_outline)
            {
                _outline.OutlineColor = Color.green;
            }
            _scoreManager.IncreaseScore(ScoreValue, true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _gameOverManager.TriggerGameOver();
        }
    }
}
