using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float attackDelay;

    public Transform attackOrigin;
    public float attackHitboxSize;
    private Vector2 attackHitbox;
    public LayerMask playerMask;
    public int attackDamage;
    public float cooldownTime;
    float cooldownTimer = 0f;
    public float[][] attackPatterns;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackPatterns = new float[][]
        {
            new float[] { 1f }, // Pattern 1: Attack in a square area
            new float[] { 2f }, // Pattern 2: Attack in a larger square area
            new float[] { 1.5f } // Pattern 3: Attack in a smaller square area
        };

        attackHitboxSize = attackPatterns[Random.Range(0, attackPatterns.Length)][0];

        attackHitbox = new Vector2(attackHitboxSize, attackHitboxSize * 1.5f);
        playerMask = LayerMask.GetMask("Player");
        attackDamage = 25;
        cooldownTime = 2f;
    }

    void Attack()
    {
        Collider2D[] player = Physics2D.OverlapBoxAll(attackOrigin.position, attackHitbox, 0f, playerMask);
        if (player.Length > 0)
        {
            Debug.Log("Player is in attack range!");
            Debug.Log("Cooldown timer: " + cooldownTimer);
            foreach (var p in player)
            {
                p.GetComponent<HealthManager>().TakeDamage(attackDamage);
            }
            cooldownTimer = cooldownTime;

            attackHitboxSize = attackPatterns[Random.Range(0, attackPatterns.Length)][0];
            attackHitbox = new Vector2(attackHitboxSize, attackHitboxSize * 1.5f);
        }
    }

    void checkCooldown()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            return;
        }
        else
        {
            Attack();
        }
    }

    void OnDrawGizmos()
    {
        if(cooldownTimer > cooldownTime - 0.1f)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(attackOrigin.position, attackHitbox);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(attackOrigin.position, attackHitbox);
        }
    }

    void Update()
    {
        checkCooldown();
    }
}
