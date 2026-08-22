using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject enemyObject;
    [Serialize] public float respawnDelay = 1f;
    public GameObject enemyPrefab;
    public float maxNumEnemy = 1f;
    public float currentNumEnemy = 0;
    public GameObject gameController;
    void Start()
    {
        currentNumEnemy = 0;
    }

    public void OnEnemyDeath()
    {
        GameController gc = gameController.GetComponent<GameController>();
        StartCoroutine(RespawnTimer());
        currentNumEnemy = 0;
        gc.ScoreOnEnemyDefeat();
        Debug.Log("REspawn ahahaha");

    }

    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnNewEnemy();
    }
    public void SpawnNewEnemy()
    {
        Debug.Log("hi" + currentNumEnemy.ToString());
        if (currentNumEnemy <= 0)
        {
            Debug.Log("hello");
            enemyObject = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            currentNumEnemy++;
        }
    }

    public void StartSpawnEnemy()
    {
        currentNumEnemy = 0;
        enemyObject = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        currentNumEnemy++;
    }
}

