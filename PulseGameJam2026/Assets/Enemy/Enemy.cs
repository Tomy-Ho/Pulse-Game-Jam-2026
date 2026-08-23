using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        Idle,
        Walking,
        Attacking
    }

    private State currentState;
    public float cooldown;
    public bool isInterrupted = false;
    public float isInterruptedCooldown;
    private SpriteRenderer enemySpriteRenderer;
    public Enemy enemy;
    public Sprite enemyIdle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = State.Idle;
        cooldown = Random.Range(1f, 3f);
        enemySpriteRenderer = enemy.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            Debug.Log(cooldown);
        }
        if(isInterruptedCooldown > 0)
        {
            isInterrupted = true;
            isInterruptedCooldown -= Time.deltaTime;
        }
        else
        {
            isInterrupted = false;
        }
        if(isInterrupted == true)
        {
            Debug.Log("INTERRUPTION");
            return;
        }
        switch (currentState)
        {
            case State.Idle:
                enemySpriteRenderer.sprite = enemyIdle;
                enemy.transform.localScale = new Vector3(0.51f, 0.51f, 0.51f);
                // Handle idle behavior
                float probability = Random.Range(0f, 1f);
                if (probability < 0.1f)
                {
                    currentState = State.Attacking;
                }
                else if (probability < 0.8f)
                {
                    currentState = State.Walking;
                }
                else
                {
                    currentState = State.Idle;
                }
                Debug.Log("Enemy is idle!");
                break;
            case State.Walking:
                enemySpriteRenderer.sprite = enemyIdle;
                enemy.transform.localScale = new Vector3(0.51f, 0.51f, 0.51f);
                EnemyMovement enemyMovement = new EnemyMovement();
                GameObject playerPos = GameObject.FindGameObjectWithTag("Player");
                GameObject ghostPos = GameObject.FindGameObjectWithTag("GhostPlayer");
                if(playerPos != null)
                {
                    if (Vector2.Distance(transform.position, playerPos.transform.position) > 2f)
                    {
                        enemyMovement.walkingsim(this.transform);
                    }
                }

                if(ghostPos != null)
                {
                    if (Vector2.Distance(transform.position, ghostPos.transform.position) > 2f)
                    {
                        enemyMovement.walkingsim(this.transform);
                    }
                }
                

                enemyMovement.stareAtPlayer(this.transform);
                if (Random.Range(0f, 1f) < 0.3f)
                {
                    currentState = State.Attacking;
                }
                else
                {
                    currentState = State.Walking;
                }
                Debug.Log("Enemy is walking!");
                break;
            case State.Attacking:
                if (cooldown <= 0)
                {
                    EnemyAttackv2.instance.attack(this.transform);
                    cooldown = Random.Range(1f, 3f);
                    isInterruptedCooldown = 1f;
                }
                currentState = State.Idle; // Return to idle after attackings
                break;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
    }
}
