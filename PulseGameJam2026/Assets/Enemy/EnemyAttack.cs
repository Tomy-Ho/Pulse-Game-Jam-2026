using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float attackDelay;

    public Transform attackOrigin;
    public float attackHitboxSize = 1f;
    private Vector2 attackHitbox;
    public LayerMask playerMask;
    public int attackDamage = 50;
    public float cooldownTime = 0.5f;
    float cooldownTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackHitbox = new Vector2(attackHitboxSize, attackHitboxSize * 1.5f);
        playerMask = LayerMask.GetMask("Player");
    }

    void Attack()
    {
        if(cooldownTimer <= 0)
        {
            Collider2D[] player = Physics2D.OverlapBoxAll(attackOrigin.position, attackHitbox, 0f, playerMask);
            foreach (var p in player)
            {
                p.GetComponent<HealthManager>().TakeDamage(attackDamage);
            }
            cooldownTimer = cooldownTime;
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackOrigin.position, attackHitbox);
    }

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else
        {
            Attack();
        }
    }
}
