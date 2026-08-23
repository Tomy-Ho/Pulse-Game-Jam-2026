using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackv2 : MonoBehaviour
{

    public static EnemyAttackv2 instance{get; private set;}
    public GameObject Enemy;
    Attackpatterns.AttackPattern attackPattern = new Attackpatterns.AttackPattern();
    private float playerToEnemyDistance;
    public float gaugeMultiplier;

    public Transform attackOrigin;
    public Vector2 attackHitbox;
    public LayerMask playerMask;
    public int attackDamage = 50;
    public float[] attackInfos;
    public float attackDelay;
    private SpriteRenderer enemySpriteRenderer;
    public Sprite punchSprite;
    public Sprite bombSprite;
    public Sprite stompSprite;
    public Sprite laserSprite;
    public Sprite GpunchSprite;
    public Sprite GbombSprite;
    public Sprite GstompSprite;
    public Sprite GlaserSprite;

    void Start()
    {
        enemySpriteRenderer = Enemy.GetComponent<SpriteRenderer>();
        if(instance != null && instance == this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void attack(Transform enemyTransform)
    {
        Debug.Log("Enemy is attacking!");
        playerToEnemyDistance = Vector2.Distance(enemyTransform.position, EnemyMovement.instance.target.transform.position);
        Debug.Log("Player to Enemy Distance: " + playerToEnemyDistance);
        gaugeDistance(playerToEnemyDistance);
    }

    public void gaugeDistance(float playerToEnemyDistance)
    {
        switch (playerToEnemyDistance)
        {
            case < 3f:
                Debug.Log("Player is very close!");
                gaugeMultiplier = 0.5f;
                break;
            case < 6f:
                Debug.Log("Player is close!");
                gaugeMultiplier = 1f;
                break;
            case < 9f:
                Debug.Log("Player is far!");
                gaugeMultiplier = 1.5f;
                break;
            default:
                Debug.Log("PLayer is very far");
                gaugeMultiplier = 2f;
                break;
        }
        chooseAttackpatternv2(gaugeMultiplier);
    }

    public void chooseAttackpatternv2(float gauge)
    {
        float probability = UnityEngine.Random.Range(0f, 1f);
        Debug.Log(probability * gaugeMultiplier);
        switch (probability * gaugeMultiplier)
        {
            case < 0.25f:
                Debug.Log("Enemy is using Flat Attack!");
                if(Enemy.tag == "Enemy"){
                    Enemy.transform.localScale = new Vector3(0.43f, 0.43f, 0.43f);
                    enemySpriteRenderer.sprite = stompSprite;

                }
                else if(Enemy.tag == "GhostEnemy"){
                    Enemy.transform.localScale = new Vector3(0.43f, 0.43f, 0.43f);
                    enemySpriteRenderer.sprite = GstompSprite;
                }
                attackPattern = Attackpatterns.AttackPattern.FlatAttack;
                break;
            case < 0.5f:
                Debug.Log("Enemy is using Front Attack!");
                if(Enemy.tag == "Enemy"){
                    Enemy.transform.localScale = new Vector3(0.51f, 0.51f, 0.51f);
                    enemySpriteRenderer.sprite = punchSprite;
                }
                else if(Enemy.tag == "GhostEnemy"){
                    Enemy.transform.localScale = new Vector3(0.51f, 0.51f, 0.51f);
                    enemySpriteRenderer.sprite = GpunchSprite;
                }
                attackPattern = Attackpatterns.AttackPattern.FrontAttack;
                break;
            case < 0.75f:
                Debug.Log("Enemy is using Big Area Attack!");
                if(Enemy.tag == "Enemy"){
                    Enemy.transform.localScale = new Vector3(0.51f, 0.51f, 0.51f);
                    enemySpriteRenderer.sprite = bombSprite;
                }
                else if(Enemy.tag == "GhostEnemy"){
                    Enemy.transform.localScale = new Vector3(0.51f, 0.51f, 0.51f);
                    enemySpriteRenderer.sprite = GbombSprite;
                }
                attackPattern = Attackpatterns.AttackPattern.BigAreaAttack;
                break;
            default:
                Debug.Log("Enemy is using Laser Attack!");
                if(Enemy.tag == "Enemy"){
                    Enemy.transform.localScale = new Vector3(0.51f, 0.51f, 0.51f);
                    enemySpriteRenderer.sprite = laserSprite;
                }
                else if(Enemy.tag == "GhostEnemy"){
                    Enemy.transform.localScale = new Vector3(0.51f, 0.51f, 0.51f);
                    enemySpriteRenderer.sprite = GlaserSprite;
                }
                attackPattern = Attackpatterns.AttackPattern.LaserAttack;
                break;
        }
        collectAttackInfos(attackPattern);
    }

    public void collectAttackInfos(Attackpatterns.AttackPattern attackPattern)
    {
        Debug.Log("Collecting attack infos for pattern: " + attackPattern);
        Attackpatterns.AttackPatternInfo attackPatternInfo = new Attackpatterns.AttackPatternInfo(attackPattern);
        attackInfos = attackPatternInfo.parameters;
        attackDelay = attackPatternInfo.timeToAttack;

        //TODO:falsche parameter daten, pattern nicht richtig uebergeben
        Debug.Log("attackInfos:" +  attackInfos + " " + attackPattern);
        executeAttack(attackInfos, attackDelay);
    }

    public void executeAttack(float[] attackInfos, float attackDelay)
    {
            playerMask = LayerMask.GetMask("Player");
            foreach(float i in attackInfos)
            {
                Debug.Log(i);
            }
            attackOrigin.position = Enemy.transform.position - new Vector3(attackInfos[0], attackInfos[1], 0f);
            attackHitbox = new Vector2(attackInfos[2], attackInfos[3]);
            Collider2D[] player = Physics2D.OverlapBoxAll(attackOrigin.position, attackHitbox, 0f, playerMask);
            if (player.Length > 0)
            {
                player[0].GetComponent<HealthManager>().TakeDamage(attackDamage);
                Debug.Log("ATTENTION: " + attackDamage);
            }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(attackOrigin.position, attackHitbox);
    }

}
