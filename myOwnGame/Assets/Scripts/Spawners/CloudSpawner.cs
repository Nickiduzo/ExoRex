using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] clouds;

    [SerializeField] private Transform firstPosition;
    [SerializeField] private Transform lastPosition;

    private List<GameObject> mainClouds;

    private void Start()
    {
        InitializeClouds();
    }

    private void Update()
    {
        DeactivateCloud();
        ActivateCloud();
    }

    private void ActivateCloud()
    {
        GameObject cloud = mainClouds.FirstOrDefault(x => !x.activeSelf);
        cloud.transform.position = RandomPosition();
        cloud.SetActive(true);
    }

    private void DeactivateCloud()
    {
        foreach (var cloud in mainClouds)
        {
            if(cloud.transform.position.x >= lastPosition.position.x)
            {
                cloud.gameObject.SetActive(false);
            }
        }        
    }
    private void InitializeClouds()
    {
        mainClouds = new List<GameObject>();

        for (int i = 0; i < 20; i++)
        {
            mainClouds.Add(SpawnCloud());
        }
    }
    private GameObject SpawnCloud()
    {
        int cloudIndex = UnityEngine.Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[cloudIndex], RandomPosition(), Quaternion.identity);
        cloud.transform.parent = transform;

        return cloud;
    }

    private Vector2 RandomPosition()
    {
        float bottomLimitY = 1f;
        float upperLimitY = 3f;

        float randomX = UnityEngine.Random.Range(firstPosition.position.x - 3f,firstPosition.position.x);
        float randomY = UnityEngine.Random.Range(bottomLimitY, upperLimitY);

        return new Vector2(randomX, randomY);
    }
}
