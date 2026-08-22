using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject enemyPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        ObjectDeath();
        healthBar.SetCurrentHealth(currentHealth);
    }

   void ObjectDeath()
    {
        if(currentHealth <= 0)
        {
           enemyPrefab.GetComponent<EnemyRespawn>().OnEnemyDeath();
            Destroy(gameObject);
        }
    }
}
