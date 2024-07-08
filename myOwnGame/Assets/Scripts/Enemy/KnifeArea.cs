using UnityEngine;

public class KnifeArea : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            anim.SetTrigger("isAttacking");
            playerHealth.DecreaseHealth(25);
        }
    }
}
