using UnityEngine;

public class EnemyPatroller : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator anim;
    [SerializeField] private Transform enemy;
    [SerializeField] private float patrolSpeed = 2f;
    [SerializeField] private float chaseSpeed = 4f;
    [SerializeField] private float idleDuration = 2f;
    [SerializeField] private float detectionRange = 5f;

    [Header("Patrol Boundaries")]
    [SerializeField] private Vector2 leftCornerOffset = new Vector2(-5, 0);
    [SerializeField] private Vector2 rightCornerOffset = new Vector2(5, 0);

    private Vector2 leftCorner;
    private Vector2 rightCorner;
    private Vector3 unitScale;

    private bool movingLeft = true;
    private bool isChasing = false;
    private float idleTimer = 0f;

    private Transform player;

    private void Awake()
    {
        unitScale = enemy.localScale;
        SetPatrolBoundaries();
    }

    private void SetPatrolBoundaries()
    {
        leftCorner = new Vector2(transform.position.x + leftCornerOffset.x, transform.position.y);
        rightCorner = new Vector2(transform.position.x + rightCornerOffset.x, transform.position.y);
    }

    private void Update()
    {
        if (!isChasing)
        {
            Patrol();
            CheckForPlayer();
        }
        else
        {
            ChasePlayer();
        }
    }

    private void Patrol()
    {
        if (movingLeft)
        {
            if (enemy.position.x > leftCorner.x)
                MoveInDirection(-1);
            else
                ChangeDirection();
        }
        else
        {
            if (enemy.position.x < rightCorner.x)
                MoveInDirection(1);
            else
                ChangeDirection();
        }
    }

    private void ChasePlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - enemy.position).normalized;
            enemy.Translate(direction * chaseSpeed * Time.deltaTime);
        }
    }
    private void CheckForPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                player = collider.transform;
                StartChasing();
                break;
            }
        }
    }
    private void StartChasing()
    {
        isChasing = true;
        anim.SetBool("isMoving", true);
    }
    private void ChangeDirection()
    {
        anim.SetBool("isMoving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer >= idleDuration)
        {
            movingLeft = !movingLeft;
            idleTimer = 0f;
        }
    }
    private void MoveInDirection(int direction)
    {
        idleTimer = 0;
        anim.SetBool("isMoving", true);

        enemy.localScale = new Vector3(Mathf.Abs(unitScale.x) * direction, unitScale.y, unitScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * patrolSpeed, enemy.position.y, enemy.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
