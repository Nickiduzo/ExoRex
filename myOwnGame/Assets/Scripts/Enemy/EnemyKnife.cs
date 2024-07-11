using UnityEngine;
using System.Collections;

public class EnemyKnife : MonoBehaviour
{
    [SerializeField] private int damageToPlayer = 20;
    [SerializeField] private float attackCooldown = 1.5f;
    [SerializeField] protected Animator anim;

    protected Transform player;
    protected bool canAttack = true;
    private Collider2D attackCollider;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            AttackPlayer();
        }
    }
    protected virtual void AttackPlayer()
    {
        anim.SetTrigger("isAttacking");
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DecreaseHealth(damageToPlayer);
        }
        StartCoroutine(AttackCooldown());
    }

    protected virtual IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(gameObject.transform.position, 0.1f);
    }
}
