using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeArea : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void OnTriggerStay2D(Collider2D collision)
    {
        MovingPlayer player;
        if (collision.TryGetComponent<MovingPlayer>(out player))
            anim.SetTrigger("isAttacking");
    }
}
