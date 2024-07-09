using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float patrolSpeed = 2f;
    [SerializeField] protected float chaseSpeed = 2.5f;
    [SerializeField] protected float detectionRange = 4f;

    protected bool isChasing = false;
    protected bool playerDetectionOnce = false;
    protected Transform player;
    protected Vector3 originalPosition;
    private Vector3 initialPlayerPosition;

    private float leftEdge;
    private float rightEdge;
    private bool movingRight = true;

    protected Animator anim;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        originalPosition = transform.position;

        leftEdge = transform.position.x - detectionRange;
        rightEdge = transform.position.x + detectionRange;
    }

    protected virtual void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
            CheckForPlayer();
        }
    }

    // logic for patroling
    protected virtual void Patrol()
    {
        if (movingRight)
        {
            if (transform.position.x < rightEdge)
            {
                Move(Vector3.right * patrolSpeed);
            }
            else
            {
                movingRight = false;
            }
        }
        else
        {
            if (transform.position.x > leftEdge)
            {
                Move(Vector3.left * patrolSpeed);
            }
            else
            {
                movingRight = true;
            }
        }
    }

    protected virtual void Move(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime);
        anim.SetBool("isMoving", true);
        if (direction.x > 0 && transform.localScale.x < 0 || direction.x < 0 && transform.localScale.x > 0)
        {
            Flip();
        } 
    }
    // logic for chasing player
    protected virtual void ChasePlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0; // Ignore Y axis for movement
            Move(direction * chaseSpeed);
        }
    }

    // logic for checking for player
    protected virtual void CheckForPlayer()
    {
        Vector2 boxSize = new Vector2(detectionRange * 2, detectionRange);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxSize,0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                if(!playerDetectionOnce)
                {
                    playerDetectionOnce = true;
                    initialPlayerPosition = collider.transform.position;
                }
                else
                {
                    player = collider.transform;
                    isChasing = true;
                }
                break;
            }
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector2 boxSize = new Vector2(detectionRange * 2, detectionRange);

        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}
