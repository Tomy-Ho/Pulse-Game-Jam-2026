using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private float score = 0f;
    public TMP_Text scoreText;
    void Start()
    {
        UpdateScoreText();
    }

    public void ScoreOnEnemyDefeat()
    {
        score++;
        Debug.Log("hahaha");
        UpdateScoreText();
    }

    public void ResetScore()
    {
        score = 0f;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        Debug.Log("Score: " + score.ToString());
        scoreText.text = "Score: " + score.ToString();
    }
}
