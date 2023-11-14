using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float speed;
    private void Awake()
    {
        speed = RandomSpeed();
    }
    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    private float RandomSpeed()
    {
        return UnityEngine.Random.Range(0.3f, 0.8f);
    }
}
