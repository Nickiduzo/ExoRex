using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 140f;
    [SerializeField] private Rigidbody2D rb;

    private bool isFacingLeft = false;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalDirection)
    {
        if (horizontalDirection < 0 && !isFacingLeft)
        {
            Flip();
        }
        // Если персонаж двигается вправо и он ранее был направлен влево, выполнить поворот
        else if (horizontalDirection > 0 && isFacingLeft)
        {
            Flip();
        }

        rb.velocity = new Vector2(horizontalDirection * speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    private void Flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
