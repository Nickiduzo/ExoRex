using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;
    protected int currentHealth;

    [SerializeField] protected float patrolSpeed = 2f;
    [SerializeField] protected float chaseSpeed = 2.5f;
    [SerializeField] protected float detectionRange = 4f;

    protected bool isChasing = false;
    protected Transform player;
    protected Vector3 originalPosition;

    protected Animator anim;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        originalPosition = transform.position;
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

    }

    // logic for chasing player
    protected virtual void ChasePlayer()
    {

    }

    // logic for checking for player
    protected virtual void CheckForPlayer()
    {

    }
    protected virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 from = new Vector3(transform.position.x + detectionRange, transform.position.y, 0);
        Vector3 to = new Vector3(transform.position.x - 2, transform.position.y, 0);
        Gizmos.DrawLine(transform.position, transform.position / detectionRange);
    }
}
