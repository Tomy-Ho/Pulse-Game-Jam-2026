using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    float attackDelay;

    public Transform attackOrigin;
    public float attackRadius = 1f;
    public LayerMask enemyMask;
    public int attackDamage = 25;
    public int selfDamage = 50;
    public float cooldownTime = 0.5f;
    public GameObject playerObject;
    float cooldownTimer = 0f;
    private HealthManager playerHealth;
    public GameObject player;
    public bool canAttack = true;
  

    [HideInInspector] public bool isGhost = false;

    [NonSerialized] public InputSystem_Actions actions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        actions = new InputSystem_Actions();
        actions.Player.Attack.AddBinding("<Mouse>/leftButton");
        
    }

    void OnEnable()
    {
        actions.Player.Enable();
        actions.Player.Attack.performed += OnAttack;
    }

    void OnDisable()
    {
        actions.Player.Attack.performed -= OnAttack;
        actions.Player.Disable();
    }
    void Start()
    {
        playerHealth = player.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void OnAttack(InputAction.CallbackContext ctx)
    {
        if(canAttack){
            playerHealth.currentHealth -= selfDamage;
            playerHealth.healthBar.SetCurrentHealth(playerHealth.currentHealth);
            if(cooldownTimer <= 0)
            {
                Collider2D[] enemy = Physics2D.OverlapCircleAll(attackOrigin.position, attackRadius, enemyMask);
                foreach (var enemies in enemy)
                {
                    if (enemies.tag.Equals("GhostEnemy"))
                    {
                        if (isGhost)
                        {
                            enemies.GetComponent<HealthManager>().TakeDamage(attackDamage); 
                        } 
                    else
                        {
                            UnityEngine.Debug.Log("Switch player form to ghost");
                        }
                    return;
                    }
                
                    if(enemies.tag.Equals("Enemy"))
                    {
                        if (!isGhost)
                        {
                            enemies.GetComponent<HealthManager>().TakeDamage(attackDamage); 
                        }
                    } 
                }
                cooldownTimer = cooldownTime;
                
                
                
            }
            else
            {
                cooldownTimer -= Time.deltaTime;
            }
            if(playerHealth.currentHealth <= 0){
                playerHealth.onObjectDeath();
            }   
        }
    }

    void OnDrawGizmos()
    {   
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackOrigin.position, attackRadius);
    }

    void Update()
    {
        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;
    }
}
