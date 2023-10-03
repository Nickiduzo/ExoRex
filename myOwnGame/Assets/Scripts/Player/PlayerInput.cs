using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private SpriteOrientation spriteOrientation;
    [SerializeField] private JumpAbility jumpAbility;
    private float horizontal;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpAbility?.Jump();
    }

    private void FixedUpdate()
    {
        movement?.Move(horizontal);
        spriteOrientation?.Flip(horizontal);
    }
}
