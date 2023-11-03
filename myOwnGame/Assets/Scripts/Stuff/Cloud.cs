using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private float cloudSpeed = 1.3f;

    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * cloudSpeed * Time.deltaTime);
        if (transform.position.x >= 78f)
        {
            gameObject.SetActive(false);
        }
    }
}
