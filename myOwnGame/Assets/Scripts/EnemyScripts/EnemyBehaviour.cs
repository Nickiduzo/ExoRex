using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("AttackParametrs")]
    [SerializeField] private float range;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private int enemyDamage = 30;

    [Header("Colliders")]
    [SerializeField] private BoxCollider2D areaOfPatrol;
    [SerializeField] private float colliderDistance;

    [Header("Player Mask")]
    [SerializeField] private LayerMask playerMask;
    private float coolDownTimer = Mathf.Infinity;

    [SerializeField]
    public MovingPlayer healthPlayer;
    private Animator anim;

    private EnemyPatroller enemyPatroller;
    private HealthPoints healthPoints;
    private Death death;
    
    AudioManager audioManager;
    public string zombieAttackSound = "ZombieAttack";

    private void Start()
    {
        death = GetComponent<Death>();
        death.OnDieActivate += ActivateDieBehaviour;

        healthPoints = GetComponent<HealthPoints>();
        enemyPatroller = GetComponentInParent<EnemyPatroller>();
        anim = GetComponent<Animator>();

        audioManager = AudioManager.instance;
    }
    private void OnDestroy()
    {
        death.OnDieActivate -= ActivateDieBehaviour;
    }
    private void Update()
    {
        attackCoolDown += Time.deltaTime;

        if (PlayerIsNearly() == true)
        {
            if (coolDownTimer >= attackCoolDown)
            {
                attackCoolDown = 0;
                anim.SetTrigger("isAttacking");
            }
        }

        if (enemyPatroller != null)
        {
            enemyPatroller.enabled = !PlayerIsNearly();
        }
    }
    public void ActivateDieBehaviour()
    {
        anim.SetTrigger("isDie");
        this.enabled = false;
    }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("isTakeDamage");
        healthPoints.DecreaseHealth(damage);
    }
    private bool PlayerIsNearly()
    {
        RaycastHit2D hit = Physics2D.BoxCast(areaOfPatrol.bounds.center + transform.right * range * transform.localScale.x * colliderDistance
            ,new Vector3(areaOfPatrol.bounds.size.x * range, areaOfPatrol.bounds.size.y,areaOfPatrol.bounds.size.z),
            0, Vector2.left,0,playerMask);

        if (hit.collider != null)
        {
            healthPlayer = hit.transform.GetComponent<MovingPlayer>();
            audioManager.PlaySound(zombieAttackSound);
        }

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(areaOfPatrol.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(areaOfPatrol.bounds.size.x * range, areaOfPatrol.bounds.size.y, areaOfPatrol.bounds.size.z));
    }
    private void DamagePlayer()
    {
        if (PlayerIsNearly()) healthPlayer.TakeDamage(enemyDamage);
    }
}
