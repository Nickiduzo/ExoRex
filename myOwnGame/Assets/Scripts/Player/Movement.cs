using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 140f;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalDirection)
    {
        rb.velocity = new Vector2(horizontalDirection * speed * Time.fixedDeltaTime, rb.velocity.y);
    }
}
