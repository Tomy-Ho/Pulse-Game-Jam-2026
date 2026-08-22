using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private float score = 0f;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        UpdateScoreText();
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreText();
    }

    public void ResetScore()
    {
        score = 0f;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
