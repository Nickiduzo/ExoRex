using UnityEngine;

public class Titanium : MonoBehaviour
{
    [SerializeField] private GameObject titanium;
    [SerializeField] private ParticleSystem destroyEffect;
    [SerializeField] private GameObject player;

    private Animator animator;
    private PlayerInput playerInput;
    private GameObject boer;
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = player.GetComponent<PlayerInput>();

        boer = playerInput.FindObject("Boer");
    }

    private void OnMouseDrag()
    {
        float pickupRadius = 0.5f;
        float playerX = player.transform.position.x;
        float itemX = gameObject.transform.position.x;

        if (Mathf.Abs(playerX - itemX) <= pickupRadius && boer.gameObject.activeSelf)
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
        System.Random rand = new System.Random();
        int amount = rand.Next(0, 3);
        for (int i = 0; i < amount; i++)
        {
            Instantiate(titanium,spawnVector,Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
