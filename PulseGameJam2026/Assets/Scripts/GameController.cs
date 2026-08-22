using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance
    {
        get;
        private set;
    }

    public GameObject scoreManager;
    public GameObject playerObject;

    public GameObject enemyRespawn;
    
    public void OnPlayerDefeat()
    {
        //if player health==0 then gameover
        if(playerObject.GetComponent<HealthManager>().currentHealth <= 0)
        {
           GameOver(); 
        }
    }

    void GameOver()
    {
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene(3);
    }

}
