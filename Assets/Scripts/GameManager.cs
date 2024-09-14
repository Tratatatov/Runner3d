using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverScreen;
    public Text ScoreText;
    private int score = 0;
    void Start()
    {
        ScoreText.text = "—чет: " + score.ToString();
    }

    void Update()
    {

    }
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }
    public void AddScore()
    {
        score++;
        ScoreText.text = "—чет: " + score.ToString();
    }
}
