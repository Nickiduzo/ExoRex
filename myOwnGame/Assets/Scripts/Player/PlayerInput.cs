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
            switch (e.keyCode)
            {
                case KeyCode.E:
                    pickupDetector?.PickupDetectedItems();
                    break;
                case KeyCode.T:
                    panelInteraction.ShowPanel(0);
                    break;
                case KeyCode.Y:
                    panelInteraction.ShowPanel(1);
                    break;
                case KeyCode.U:
                    panelInteraction.ShowPanel(2);
                    break;
                case KeyCode.I:
                    panelInteraction.ShowPanel(3);
                    break;
                case KeyCode.Escape:
                    panelInteraction.HideAll();
                    break;
            }
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
