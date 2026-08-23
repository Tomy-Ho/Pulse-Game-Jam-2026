using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject enemyObject;
    [Serialize] public float respawnDelay = 1f;
    public GameObject enemyPrefab;
    public GameObject ghostEnemyPrefab;

    public AudioClip enemySound;

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
        AudioSource.PlayClipAtPoint(enemySound,transform.position,1f);
        if (enemyObject == null)
        {
            RandomizeEnemyVariant();
        }
    }

    void RandomizeEnemyVariant()
    {
        float randomNum = Random.Range(0f, 1f);

        if (randomNum <= 0.7f)
        {
            enemyObject = Instantiate(enemyPrefab, transform.position, Quaternion.identity);    
        } 
        else
        {
            enemyObject = Instantiate(ghostEnemyPrefab, transform.position, Quaternion.identity);    

        }
    }

    public void StartSpawnEnemy()
    {
        enemyObject = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}

