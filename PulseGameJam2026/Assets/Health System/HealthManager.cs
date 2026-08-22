using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public GameObject enemyObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetCurrentHealth(currentHealth);
    }

    public void onEnemyDeath()
    {
        if (currentHealth <= 0)
        {
            EnemyRespawn er = enemyObject.GetComponent<EnemyRespawn>();

            if (gameObject.tag.Equals("Enemy"))
            {
                er.OnEnemyDeath();
            }
            else
            {
                GameController.Instance.OnPlayerDefeat();
            }
        }
    }
}
