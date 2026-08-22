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
        UpdateScoreText();

        if(Instance != null && Instance == this)
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
        UpdateScoreText();
    }

    public void ResetScore()
    {
        score = 0f;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        } 
        else
        {
            Debug.Log("No text exits");    
        }
    }
}
