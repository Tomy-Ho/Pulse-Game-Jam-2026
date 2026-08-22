using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject scoreManager;

    void Start()
    {
    }

    void OnEnemyDefeat()
    {
        //if player defeats one enemy then spawn new stronger one and increment gameScore
        scoreManager.GetComponent<ScoreManager>().IncrementScore();
    }

    void OnPlayerDefeat()
    {
        //if player health==0 then gameover
        GameOver();
    }


    void GameOver()
    {
        scoreManager.GetComponent<ScoreManager>().ResetScore();
        SceneManager.LoadScene(3);
    }

}
