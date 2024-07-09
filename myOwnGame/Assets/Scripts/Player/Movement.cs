using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 80f;
    [SerializeField] private Rigidbody2D rb;
    private GroundCheck groundCheck;
    private PlayerHealth playerHealth; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
    
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (transform.position.y < -6f)
        {
            playerHealth.DecreaseHealth(10); // Invoke the event to handle player death
        }
    }
    public void Move(float horizontalDirection)
    {
        //GameObject will slide in air
        if (!groundCheck.IsGrounded && horizontalDirection == 0)
            return;
        rb.velocity = new Vector2(horizontalDirection * speed * Time.fixedDeltaTime, rb.velocity.y);
    }
}
