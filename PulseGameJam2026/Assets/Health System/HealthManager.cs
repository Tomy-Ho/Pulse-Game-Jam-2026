using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public GameObject enemyObject;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        onObjectDeath();
        healthBar.SetCurrentHealth(currentHealth);
    }

    public void onObjectDeath()
    {
        if (currentHealth <= 0)
        {
            EnemyRespawn er = enemyObject.GetComponent<EnemyRespawn>();

            if (gameObject.tag.Equals("Enemy") || gameObject.tag.Equals("GhostEnemy"))
            {
                er.OnEnemyDeath();
            }
            else
            {
                GameController.Instance.OnPlayerDefeat();
            }
            Destroy(gameObject);
        }
    }
}
