using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public Transform target;

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
    public void walkingsim(Transform enemyTransform)
    {
        SearchRightPlayerTag();
        enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void stareAtPlayer(Transform enemyTransform)
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target.position.x - enemyTransform.position.x < 0)
        {
            enemyTransform.localScale = new Vector3(1, 1, 1);  // Nach rechts
        }
        else if (target.position.x - enemyTransform.position.x > 0)
        {
            enemyTransform.localScale = new Vector3(-1, 1, 1);  // Nach links
        }
    }
}
