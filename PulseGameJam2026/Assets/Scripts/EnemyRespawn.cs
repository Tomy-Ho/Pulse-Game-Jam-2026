using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject enemyObject;
    [Serialize] public float respawnDelay = 1f;
    public GameObject enemyPrefab;

    void Update()
    {
        if (enemyObject == null)
        {
            float timer = respawnDelay;
            timer--;
            if(timer <= 0)
            {
                SpawnNewEnemy();
            }
        }
    }

    public void OnEnemyDeath()
    {
        ScoreManager.Instance.ScoreOnEnemyDefeat();
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

