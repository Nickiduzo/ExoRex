using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private SpriteOrientation spriteOrientation;
    [SerializeField] private JumpAbility jumpAbility;
    [SerializeField] private PickupItemDetector pickupDetector;
    [SerializeField] private PanelInteraction panelInteraction;
    private float horizontal;

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
          
        }
    }
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
