using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject enemyObject;
    [Serialize] public float respawnDelay = 1f;
    public GameObject enemyPrefab;
    public float maxNumEnemy = 1f;
    public GameObject scoreManager;
 
    void Update()
    {
        if(enemyObject == null)
        {
            float timer = respawnDelay;

            if(timer <= 0)
            {
                SpawnNewEnemy();
            }
        }
    }
    public void OnEnemyDeath()
    {
        scoreManager.GetComponentInChildren<ScoreManager>().ScoreOnEnemyDefeat();
    }
    public void SpawnNewEnemy()
    {
        if (enemyObject == null)
        {
            enemyObject = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }

    public void StartSpawnEnemy()
    {
        enemyObject = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}

