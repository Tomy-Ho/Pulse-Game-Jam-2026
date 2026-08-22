using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject scoreManager;
    public GameObject playerObject;

    public GameObject enemyRespawn;

    void Start()
    {
        enemyRespawn.GetComponent<EnemyRespawn>().SpawnNewEnemy();
        Debug.Log("hahah");
    }
    void OnEnemyDefeat()
    {
        //if player defeats one enemy then spawn new stronger one and increment gameScore
        //scoreManager.GetComponent<ScoreManager>().IncrementScore();
        //enemyRespawn.GetComponent<EnemyRespawn>().SpawnNewEnemy();
    }

    void OnPlayerDefeat()
    {
        //if player health==0 then gameover
        if(playerObject.IsDestroyed())
        {
           GameOver(); 
        }
    }


    void GameOver()
    {
        scoreManager.GetComponent<ScoreManager>().ResetScore();
        SceneManager.LoadScene(3);
    }

}
