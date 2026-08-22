using UnityEngine;
public class Logic : MonoBehaviour
{
    public Transform target;
    // nachher wegmachen
    public float range;
    public float playerToEnemyDistance;
    public float baseSpeed = 2f;
    public float baseJumpForce = 4f;
    public Transform groundCheckTransform;
    public float groundCheckRadius;
    public Rigidbody2D enemy;
    public float enemySize = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SearchRightPlayerTag();
        enemy = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(enemySize, enemySize, enemySize);
    }

    // Update is called once per frame
    void Update()
    {
        playerToEnemyDistance = Vector2.Distance(transform.position, target.position);
        funnyman3(playerToEnemyDistance);

        if (target.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);  // Nach rechts
        }
        else if (target.position.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);  // Nach links
        }
        walkingsim();
    }

    void SearchRightPlayerTag()
    {
        GameObject ghostPlayerTag = GameObject.FindGameObjectWithTag("GhostPlayer");
        if (ghostPlayerTag != null)
        {
            target = GameObject.FindGameObjectWithTag("GhostPlayer").transform;  
            return;         
        } 
        
        GameObject playerTag = GameObject.FindGameObjectWithTag("Player");
        if (playerTag != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckRadius);
    }

    void walkingsim()
    {
        if (playerToEnemyDistance > 2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, baseSpeed * Time.deltaTime);
        }
    }

    void funnyman3(float playerToEnemyDistance)
    {
        switch (playerToEnemyDistance)
        {
            case < 3f:
                Debug.Log("Player is very close!");
                break;
            case < 6f:
                Debug.Log("Player is close!");

                break;
            case < 9f:
                Debug.Log("Player is far!");
                break;
        }
    }
}
