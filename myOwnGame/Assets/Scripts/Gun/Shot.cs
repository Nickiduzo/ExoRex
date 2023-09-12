using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private int damage = 40;
    private float speed = 10f;
    [SerializeField]
    private Rigidbody2D rigidBody2D;
    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = transform.right * speed;
        Destroy(gameObject,5);
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
}
