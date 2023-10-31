using UnityEngine;

public class Titanium : MonoBehaviour
{
    [SerializeField] private GameObject titanium;
    [SerializeField] private ParticleSystem destroyEffect;
    [SerializeField] private GameObject player;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseEnter()
    {
        float pickupRadius = 0.3f;
        float playerX = player.transform.position.x;
        float itemX = gameObject.transform.position.x;

        if (Mathf.Abs(playerX - itemX) <= pickupRadius)
        {
            animator.SetTrigger("Mine");
        }
    }
    private void DestroyEffect(AnimationEvent animation)
    {
        Instantiate(destroyEffect,gameObject.transform.position ,Quaternion.identity);
    }
    private void SpawnTitanium(AnimationEvent animation)
    {
        Vector3 spawnVector = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f, gameObject.transform.position.z);
        for (int i = 0; i < 4; i++)
        {
            Instantiate(titanium,spawnVector,Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
