using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoving : StateMachineBehaviour
{
    public float speed = 1.1f;
    private float attackRange = 0.3f;
    
    Transform player;
    Rigidbody2D rigidBody2D;

    BossBehaviour boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidBody2D = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossBehaviour>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rigidBody2D.position.y);
        Vector2 newPos = Vector2.MoveTowards(rigidBody2D.position, target, speed * Time.fixedDeltaTime);
        rigidBody2D.MovePosition(newPos);

        if (Vector2.Distance(player.position, rigidBody2D.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack"); 
    }
}
