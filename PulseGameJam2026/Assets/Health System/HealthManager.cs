using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public GameObject enemyObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnEnemyDeath();
        healthBar.SetCurrentHealth(currentHealth);
    }

    public void OnEnemyDeath()
    {
        if(currentHealth <= 0)
        {
        
            EnemyRespawn er = enemyObj.GetComponent<EnemyRespawn>();

            if (gameObject.tag.Equals("Enemy"))
            {
                er.OnEnemyDeath();
            }
            else
            {
                GameController.instance.OnPlayerDefeat();
            }
            
            Destroy(gameObject);
        }
    }
}
