using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    private Text _bestScoreText;
    void Awake()
    {
        _bestScoreText = GetComponent<Text>();
        SetBestScore();
    }

    private void SetBestScore()
    {
        _bestScoreText.text = $"Лучший счет: {PlayerPrefs.GetInt(Constants.BestScore).ToString()}";
    }
    
}
