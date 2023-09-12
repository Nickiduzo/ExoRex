using UnityEngine;

public class Animate : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private Animator anime;
    [SerializeField]
    private bool isRightSide = true;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.D)) anime.SetBool("isMoving", true);
        else if (Input.GetKey(KeyCode.A)) anime.SetBool("isMoving", true);
        else
        {
            anime.SetBool("isStay", true);
            anime.SetBool("isMoving", false);
        }
    }
    private void Spin()
    {
        isRightSide = !isRightSide;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
    }
}
