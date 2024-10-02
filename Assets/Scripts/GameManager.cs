using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject _gameOverScreen;
    private Transform _playerTransform;
    private Text _scoreText;
    private int _bestScore;
    private int _score = 0;

    public Transform PlayerTransform => _playerTransform;

    public void GameOver()
    {
        SaveBestScore();
        _gameOverScreen.SetActive(true);
    }

    public void AddScore()
    {
        _score++;
        ChangeScoreText();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        _scoreText = FindObjectOfType<ScoreText>().GetComponent<Text>();
        _playerTransform = FindObjectOfType<PlayerController>().transform;
        _gameOverScreen.SetActive(false);
    }

    private void Start()
    {
        ChangeScoreText();
    }

    private void SaveBestScore()
    {
        if (_score > _bestScore)
        {
            _bestScore = _score;
        }
        PlayerPrefs.SetInt(Constants.BestScore, _bestScore);
    }
    private void ChangeScoreText()
    {
        _scoreText.text = _score.ToString();
    }

}
