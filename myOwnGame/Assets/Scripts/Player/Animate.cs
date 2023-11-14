using UnityEngine;

public class Animate : MonoBehaviour
{
    [SerializeField] private bool isRightSide = true;
    
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) animator.SetBool("isMining", true);
        else if (Input.GetKey(KeyCode.D)) animator.SetBool("isMoving", true);
        else if (Input.GetKey(KeyCode.A)) animator.SetBool("isMoving", true);
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isMining", false);
        }
    }
    private void Spin()
    {
        isRightSide = !isRightSide;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
    }
}
