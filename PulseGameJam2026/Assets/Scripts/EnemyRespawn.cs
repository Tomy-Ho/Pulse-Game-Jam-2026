using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject enemyObject;
    [Serialize] public float respawnDelay = 1f;
    public GameObject enemyPrefab;

    void Start()
    {
        SpawnNewEnemy();
    }

    public void OnEnemyDeath()
    {
        if(enemyObject.GetComponent<HealthManager>().currentHealth <= 0)
        {
            StartCoroutine(RespawnTimer());
            Debug.Log("REspawn ahahaha");
        }
    }

    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnNewEnemy();
    }
    public void SpawnNewEnemy()
    {
        enemyObject = Instantiate(enemyPrefab, transform.position, Quaternion.identity); 
    }
}
