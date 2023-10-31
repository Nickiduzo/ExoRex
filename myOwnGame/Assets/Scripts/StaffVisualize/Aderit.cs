using UnityEngine;

public class Aderit : MonoBehaviour
{
    [SerializeField] private GameObject aderit;
    [SerializeField] private ParticleSystem destroyEffect;
    [SerializeField] private GameObject player;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnMouseDrag()
    {
        float pickupRadius = 1f;
        float playerX = player.transform.position.x;
        float itemX = gameObject.transform.position.x;

        if (Mathf.Abs(playerX - itemX) <= pickupRadius)
        {
            animator.SetTrigger("Mine");
        }
    }
    private void DestroyEffect(AnimationEvent animation)
    {
        Instantiate(destroyEffect, gameObject.transform.position, Quaternion.identity);
    }

    private void SpawnAderit(AnimationEvent animation)
    {
        System.Random rand = new System.Random();
        var amount = rand.Next(0, 5);
        for (int i = 0; i < amount; i++)
        {
            Instantiate(aderit, gameObject.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
