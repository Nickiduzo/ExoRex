using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody2D;
    private int damage = 40;
    private float speed = 10f;
    private Vector2 direction = Vector2.right;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = direction * speed;
        Destroy(gameObject,1.2f);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Enemy"))
        {
            HealthPoints health = hitInfo.gameObject.GetComponent<HealthPoints>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (hitInfo.gameObject.CompareTag("RexEnemy"))
        {
            HealthPoints health = hitInfo.gameObject.GetComponent<HealthPoints>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    public void SetDirection(float horizontalDirection)
    {
        if(horizontalDirection < 0)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }
    }
}
