using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D moveRigidBody;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private bool isGrounded = false;
    [SerializeField]
    private Transform groundCheck;
    private float groundRadius = 0.1f;
    [SerializeField]
    private Animator anime;

    AudioManager audioManager;
    public string jumpingAudio = "JumpAudio";
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anime.SetBool("Ground", isGrounded);
        anime.SetFloat("vSpeed", moveRigidBody.velocity.y);

        if (!isGrounded) return;
    }

    private void Start()
    {
        moveRigidBody = GetComponent<Rigidbody2D>();
        audioManager = AudioManager.instance;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            MakeJumpSound();
            anime.SetBool("Ground", false);
            moveRigidBody.AddForce(new Vector2(0, 100));
        }
    }
    public void MakeJumpSound()
    {
        audioManager.PlaySound(jumpingAudio);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) isGrounded = false;
    }
}
