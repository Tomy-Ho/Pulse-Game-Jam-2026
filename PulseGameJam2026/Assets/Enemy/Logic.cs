using UnityEngine;
public class Logic : MonoBehaviour
{
    public Transform target;
    // nachher wegmachen
    public float range;
    public float playerToEnemyDistance;
    public float speed;
    public float jumpForce;
    public Transform groundCheckTransform;
    public float groundCheckRadius;
    public Rigidbody2D enemy;
    public float enemySize = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(enemySize, enemySize, enemySize);
    }

    // Update is called once per frame
    void Update()
    {
        playerToEnemyDistance = Vector2.Distance(transform.position, target.position);
        funnyman3(playerToEnemyDistance);

        walkingsim();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckRadius);
    }

    void walkingsim()
    {
        /*
        if (target.GetComponent<PlayerMovement>().isGrounded == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, -2.5f), speed * Time.deltaTime);
        }
        else
        {
        }*/
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

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
