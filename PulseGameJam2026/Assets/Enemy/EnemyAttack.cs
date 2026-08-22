using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float attackDelay;

    public Transform attackOrigin;
    private Vector2 attackHitbox;
    public LayerMask playerMask;
    public int attackDamage;
    public float cooldownTime;
    float cooldownTimer = 0f;
    public float[] attackInfos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        getAttackInfos();
        playerMask = LayerMask.GetMask("Player");
        attackDamage = 25;
        cooldownTime = 2f;
    }

    void getAttackInfos()
    {
        attackInfos =  new Attackpatterns().attackPatterns[Random.Range(0, new Attackpatterns().attackPatterns.Length)];
        attackOrigin.position = new Vector2(transform.position.x + attackInfos[0], transform.position.y + attackInfos[1]);
        attackHitbox = new Vector2(attackInfos[2], attackInfos[3]);
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

            getAttackInfos();
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
