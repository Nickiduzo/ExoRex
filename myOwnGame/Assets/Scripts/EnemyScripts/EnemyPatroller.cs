using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroller : MonoBehaviour
{
    [Header("Patrol Points")]
    public Transform leftCorner;
    public Transform rightCorner;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parametrs")]
    [SerializeField] private float speed;
    private Vector3 unitScale;
    private bool movingLeft;

    [Header("Idle")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Animation")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        unitScale = enemy.localScale;
    }
    private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftCorner.position.x)  MoveInDirection(-1);
            else ChangeDirection();
        }
        else
        {
            if (enemy.position.x <= rightCorner.position.x) MoveInDirection(1);
            else ChangeDirection();
        }
    }
    private void OnDisable()
    {
        anim.SetBool("isMoving",false);
    }
    private void ChangeDirection()
    {
        anim.SetBool("isMoving",false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration) movingLeft = !movingLeft;
    }
    private void MoveInDirection(int direction)
    {
        idleTimer = 0;
        anim.SetBool("isMoving",true);

        enemy.localScale = new Vector3(Mathf.Abs(unitScale.x) * direction,unitScale.y,unitScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y,enemy.position.z);
    }
}
