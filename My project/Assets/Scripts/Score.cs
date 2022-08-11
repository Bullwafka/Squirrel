using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private TMP_Text _scoreView;
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private TMP_Text _coins;
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _highScorePoint;
    private float _previousPosition;
    private int _score, _highScore;
    private int _coinsCount;


    private void Start()
    {
        Physics2D.IgnoreCollision(_coin.GetComponent<Collider2D>(), _playerObj.GetComponent<Collider2D>(), true);
        if (PlayerPrefs.HasKey("HighScore") || PlayerPrefs.HasKey("Coins"))
        {
            _highScore = PlayerPrefs.GetInt("HighScore");
            _coinsCount = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            _coinsCount = 0;
            _highScore = 0;
        }
        _previousPosition = 0f;
        _highScoreText.text = "HighScore: " + _highScore.ToString();
        _coins.text = _coinsCount.ToString();
        HighScorePoint(_highScore);
    }

    private void Update()
    {
        ScoreChange((int)_playerObj.transform.position.y);
    }

    private void ScoreChange(int score)
    {
        _highScoreText.text = "HighScore: " + _highScore.ToString();
        if (_playerObj.transform.position.y > _previousPosition)
        {
            _score = score;
            _scoreView.text = score.ToString();
            _previousPosition = _playerObj.transform.position.y;
        }
    }
    public void SaveRecord()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
        PlayerPrefs.SetInt("Coins", _coinsCount);
    }
    private void OnEnable()
    {
        EventManager.PickUpCoin.AddListener(OnPickUpCoins); 
    }
    private void OnDisable()
    {
        EventManager.PickUpCoin.RemoveListener(OnPickUpCoins);
    }
    private void OnPickUpCoins(int coinsCount)
    {
        _coinsCount += coinsCount;
        _coins.text = _coinsCount.ToString();
    }
    private void HighScorePoint(int highscore)
    {
        if(highscore > 0)
        {
            _highScorePoint.transform.position = new Vector2(0, highscore);
            _highScorePoint.SetActive(true);
        }
    }
    public bool OnBuyGoods(int price)
    {
        if(_coinsCount >= price)
        {
            _coinsCount -= price;
            _coins.text = _coinsCount.ToString();
            return true;
        }
        return false;
    }
}
