using UnityEngine;

public class Animate : MonoBehaviour
{
    [SerializeField] private bool isRightSide = true;
    
    private Rigidbody2D rigidBody2D;
    private Animator animator;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) animator.SetTrigger("Mining");
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.D)) animator.SetBool("isMoving", true);
        else if (Input.GetKey(KeyCode.A)) animator.SetBool("isMoving", true);
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
    private void Spin()
    {
        isRightSide = !isRightSide;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
    }
}
