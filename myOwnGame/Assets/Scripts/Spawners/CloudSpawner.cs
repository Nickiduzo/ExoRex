using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] clouds;
    [SerializeField] private float spawnInterval;
    [SerializeField] private GameObject endPoint;

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;

        Invoke("AttemptSpawn", spawnInterval);
    }

    private void SpawnCloud()
    {
        int randomIndex = Random.Range(0,clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex]);

        cloud.transform.position = startPos;
    }

    private void AttemptSpawn()
    {
        SpawnCloud();

        Invoke("AttemptSpawn", spawnInterval);
    }
}
