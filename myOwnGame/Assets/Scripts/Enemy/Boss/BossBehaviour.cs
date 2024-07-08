using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    private Transform player;
    private BossBarElement bossBar;
    
    private int bossDamageAttack = 50;
    private float hp = 500;
    private bool isFlipedd = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossBar = FindObjectOfType<BossBarElement>();
    }
    private void OnCollisionEnter2D(Collision2D colliderPlayerInfo)
    {
        if (colliderPlayerInfo.gameObject.CompareTag("Player"))
        {
            //MovingPlayer playerHealth = colliderPlayerInfo.gameObject.GetComponent<MovingPlayer>();
            //if (playerHealth != null) playerHealth.TakeDamage(bossDamageAttack);
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
