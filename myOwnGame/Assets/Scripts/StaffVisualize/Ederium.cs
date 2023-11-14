using Unity.VisualScripting;
using UnityEngine;

public class Ederium : MonoBehaviour
{
    [SerializeField] private GameObject ederium;
    [SerializeField] private ParticleSystem destroyEffect;
    [SerializeField] private GameObject player;

    private Animator animator;
    private PlayerInput playerInput;
    private GameObject boer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInput = player.GetComponent<PlayerInput>();

        boer = playerInput.FindObject("Boer");
    }
    private void OnMouseDrag()
    {
        float pickupRadius = 1f;
        float playerX = player.transform.position.x;
        float itemX = gameObject.transform.position.x;

        if (Mathf.Abs(playerX - itemX) <= pickupRadius && boer.gameObject.activeSelf)
        {
            animator.SetTrigger("Mine");
        }
    }
    private void DestroyEffect(AnimationEvent animation)
    {
        Instantiate(destroyEffect, gameObject.transform.position, Quaternion.identity);
    }

    private void SpawnEderium(AnimationEvent animation)
    {
        System.Random rand = new System.Random();
        var amount = rand.Next(0, 4);
        for (int i = 0; i < amount; i++)
        {
            Instantiate(ederium, gameObject.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
