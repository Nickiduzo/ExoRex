using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private int enemyDamage = 30;
    [SerializeField] private LayerMask playerMask;

    [Header("Components")]
    [SerializeField] private BoxCollider2D areaOfPatrol;
    private Animator anim;
    private HealthPoints healthPoints;

    [Header("Loot Settings")]
    [SerializeField]
    private Loot[] possibleLoots = new Loot[]
    {
        new Loot { lootType = LootType.Ederium, minAmount = 1, maxAmount = 2, dropChance = 15f },
        new Loot { lootType = LootType.Titanium, minAmount = 1, maxAmount = 1, dropChance = 1f },
        new Loot { lootType = LootType.Aderit, minAmount = 1, maxAmount = 5, dropChance = 84f }
    };

    private float cooldownTimer = Mathf.Infinity;

    private void Start()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        anim = GetComponent<Animator>();
        healthPoints = GetComponent<HealthPoints>();
    }

    private void Update()
    {
        UpdateAttackCooldown();
    }

    private void UpdateAttackCooldown()
    {
        cooldownTimer += Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("isTakeDamage");
        healthPoints.DecreaseHealth(damage);
    }

    private void OnDestroy()
    {
        DropLoot();
    }

    private void DropLoot()
    {
        LootManager.Instance.DropLoot(possibleLoots, transform.position);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerHealth player;
        if (collision.TryGetComponent<PlayerHealth>(out player))
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
            }
        }
    }
}
