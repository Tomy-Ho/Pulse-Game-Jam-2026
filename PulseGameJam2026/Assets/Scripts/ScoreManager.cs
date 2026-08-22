using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance
    {
        get;
        private set;
    }
    private float score = 0f;
    public TMP_Text scoreText;

    void Awake()
    {
        if (Instance != null && Instance == this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        ResetScore();
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
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.Log("error, no scoretext");
        }
    }
}
