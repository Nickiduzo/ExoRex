using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class BossBehaviour : MonoBehaviour
{
    private float hp = 500;
    private int bossDamageAttack = 50;
    private bool isFlipedd = true;

    Transform player;
    MovingPlayer playerHealth;
    BossBarElement bossBar;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = FindObjectOfType<MovingPlayer>();
        bossBar = FindObjectOfType<BossBarElement>();
    }
    private void OnCollisionEnter2D(Collision2D colliderPlayerInfo)
    {
        if (colliderPlayerInfo.gameObject.CompareTag("Player"))
        {
            MovingPlayer playerHealth = colliderPlayerInfo.gameObject.GetComponent<MovingPlayer>();
            if (playerHealth != null) playerHealth.TakeDamage(bossDamageAttack);
        }
    }
    public void TakeDamage(int value)
    {
        if (hp > 0)
        {
            hp -= value;
            bossBar.SetMainValue(value);
        }
        else if (hp <= 0) BossDie();
    }
    private void BossDie()
    {
        Destroy(gameObject);
        bossBar.OnDestroy();
    }
    public void LookAtPlayer()
    {
        if (transform.position.x > player.position.x && isFlipedd)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipedd = false;
        }
        else if (transform.position.x < player.position.x && !isFlipedd)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipedd = true;
        }
    }
}
