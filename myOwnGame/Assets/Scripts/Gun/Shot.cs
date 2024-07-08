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
        Destroy(gameObject,1.5f);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyBehaviour enemy =  hitInfo.GetComponent<EnemyBehaviour>();
        BossBehaviour bossHp = hitInfo.GetComponent<BossBehaviour>();
        if (enemy != null)
        {
            Destroy(gameObject);
            enemy.TakeDamage(damage);
        }
        else if (bossHp != null)
        {
            Destroy(gameObject);
            bossHp.TakeDamage(damage);
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
