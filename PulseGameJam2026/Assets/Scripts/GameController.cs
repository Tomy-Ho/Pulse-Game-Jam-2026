using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance
    {
        get;
        private set;
    }
    public GameObject playerObject;

    public GameObject enemyRespawn;

    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
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
