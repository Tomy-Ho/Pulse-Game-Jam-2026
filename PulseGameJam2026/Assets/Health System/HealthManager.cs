using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        healthBar.SetCurrentHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
