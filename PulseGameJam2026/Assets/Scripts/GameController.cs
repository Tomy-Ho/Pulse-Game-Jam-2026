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
        enemyRespawn.GetComponent<EnemyRespawn>().StartSpawnEnemy();
        Debug.Log("hahah");
        Debug.Log(enemyRespawn.GetComponent<EnemyRespawn>().currentNumEnemy.ToString());
    }
    public void ScoreOnEnemyDefeat()
    {
        scoreManager.GetComponent<ScoreManager>().IncrementScore();
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
