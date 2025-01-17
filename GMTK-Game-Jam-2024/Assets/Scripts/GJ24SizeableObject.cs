using TMPro;
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
    bool _metTargetSize;
    public int ScoreValue;
    [SerializeField]
    GameObject _scoreTextObject;
    [SerializeField]
    Transform _scoreTextObjectPos;
    GJ24ScoreManager _scoreManager;
    GJ24GameOverManager _gameOverManager;
    Outline _outline;

    void Start()
    {
        _groundLevel = GameObject.FindGameObjectWithTag("GroundLevel").transform.position.y;
        _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<GJ24ScoreManager>();
        _gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GJ24GameOverManager>();
        _outline = GetComponent<Outline>();
    }
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

        if (CurrentSizeStep >= TargetSizeStep && gameObject.tag == "GrowObject" && !_metTargetSize)
        {
            _metTargetSize = true;
            if (_outline)
            {
                _outline.OutlineColor = Color.green;
            }
            SpawnScoreUI(false);
        }
    }
    public void ShrinkObject()
    {
        transform.localScale /= 2.0f;
        CurrentSizeStep--;
        if (CurrentSizeStep <= TargetSizeStep && gameObject.tag == "ShrinkObject" && !_metTargetSize)
        {
            _metTargetSize = true;
            if (_outline)
            {
                _outline.OutlineColor = Color.green;
            }
            SpawnScoreUI(true);
        }
    }
    void SpawnScoreUI(bool shrunkObject)
    {
        GameObject scoreText = Instantiate(_scoreTextObject, _scoreTextObjectPos.position, _scoreTextObject.transform.rotation);
        scoreText.GetComponent<TMP_Text>().text = "+" + ScoreValue + "!";
        _scoreManager.IncreaseScore(ScoreValue, shrunkObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !other.gameObject.GetComponent<GJ24PlayerMovement>().ShieldOn)
        {
            _gameOverManager.TriggerGameOver(true);
        }
    }
}