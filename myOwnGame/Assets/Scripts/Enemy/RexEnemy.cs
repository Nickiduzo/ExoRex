using UnityEngine;

public class RexEnemy : Enemy
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpCooldown = 2f;
    private float jumpTimer = 0f;

    protected override void Start()
    {
        base.Start();
        // Additional initialization specific to RexEnemy
        jumpTimer = jumpCooldown;
    }

    protected override void Update()
    {
        base.Update();
        // Additional logic specific to RexEnemy
        if (isChasing)
        {
            if (jumpTimer <= 0f)
            {
                Jump();
                jumpTimer = jumpCooldown;
            }
            else
            {
                jumpTimer -= Time.deltaTime;
            }
        }
    }
    private void Jump()
    {
        // Perform jump logic
        // For example:
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    protected override void ChasePlayer()
    {
        // Override the ChasePlayer method if necessary
        // For RexEnemy, you might want to implement different chasing behavior
        base.ChasePlayer();
        // Additional or modified chasing logic specific to RexEnemy
    }

    protected void OnDestroy()
    {
        NotifyBossDestroyed();
    }

    private void NotifyBossDestroyed() => EnemySpawner.Instance.BossDestroyed();
}
