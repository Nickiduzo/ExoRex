using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody2D;
    private int damage = 40;
    private float speed = 10f;
    private Vector2 direction;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = direction * speed;
        Destroy(gameObject, 1.2f);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Enemy") || hitInfo.gameObject.CompareTag("RexEnemy"))
        {
            HealthPoints health = hitInfo.gameObject.GetComponent<HealthPoints>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
