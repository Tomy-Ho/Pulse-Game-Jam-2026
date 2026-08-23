using UnityEngine;
//DEPRECATED
public class EnemyAttack : MonoBehaviour
{
    public float attackDelay;

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
        playerMask = LayerMask.GetMask("Player");
        attackDamage = 25;
        attackDelay = 1f;
        cooldownTime = Random.Range(1f, 4f);
    }



    void Attack()
    {
        Collider2D[] player = Physics2D.OverlapBoxAll(attackOrigin.position, attackHitbox, 0f, playerMask);
        if (player.Length > 0)
        {
            foreach (var p in player)
            {
                p.GetComponent<HealthManager>().TakeDamage(attackDamage);
            }
        }
        cooldownTimer = Random.Range(1f, 4f);;

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
