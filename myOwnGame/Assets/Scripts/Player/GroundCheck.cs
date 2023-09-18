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
    [SerializeField] private float validationRadius = 1.0f;
    [SerializeField] private LayerMask ignoreLayer;


    private void FixedUpdate()
    {
        IsGrounded =  !(Physics2D.OverlapCircle(validationTransform.position, validationRadius, ~ignoreLayer) is null);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(validationTransform.position, validationRadius);
    }
}
