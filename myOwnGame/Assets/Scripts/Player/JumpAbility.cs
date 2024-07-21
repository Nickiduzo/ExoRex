using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundCheck))]
public class JumpAbility : MonoBehaviour
{
    [SerializeField] private Animator anime;
    [SerializeField] private float jumpForce = 7f;
    private Rigidbody2D rb;
    private GroundCheck groundCheck;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
    }

    private void Update()
    {
        anime.SetBool("Ground", groundCheck.IsGrounded);
    }

    public void Jump()
    {
        
        if (groundCheck.IsGrounded)
        {
            ExecuteJumpFunctionality();
            //currentJumpCount = 1;
        }
        //else
        //{
        //    if (currentJumpCount < 2)
        //    {
        //        ExecuteJumpFunctionality();
        //        currentJumpCount++;
        //    }
        //}
    }
    private void ExecuteJumpFunctionality()
    {
        AudioManager.Instance.PlaySound("PlayerJump");
        anime.SetBool("Ground", false);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
