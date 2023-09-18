using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isGrounded;
    public bool IsGrounded
    {
        get { return isGrounded; }
        set
        {
            if (isGrounded != value)
                isGrounded = value;
        }
    }

    [SerializeField] private Transform validationTransform;
    [SerializeField] private LayerMask ignoreLayer;


    private void Update()
    {
        if (Physics2D.Raycast(validationTransform.position, new Vector2(0f, -0.05f), 0.05f, ~ignoreLayer))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
}
