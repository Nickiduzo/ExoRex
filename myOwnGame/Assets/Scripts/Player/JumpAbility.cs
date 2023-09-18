using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundCheck))]
public class JumpAbility : MonoBehaviour
{
    public string jumpingAudio = "JumpAudio";
    private AudioManager audioManager;

    [SerializeField] private Animator anime;
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D rb;
    private GroundCheck groundCheck;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
    }
    private void Start()
    {
        audioManager = AudioManager.instance;
    }

    private void FixedUpdate()
    {
        anime.SetBool("Ground", groundCheck.IsGrounded);
        anime.SetFloat("vSpeed", rb.velocity.y);
    }

    public void MakeJumpSound()
    {
        audioManager?.PlaySound(jumpingAudio);
    }

    public void Jump()
    {
        
        if (groundCheck.IsGrounded)
        {
            MakeJumpSound();
            anime.SetBool("Ground", false);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
