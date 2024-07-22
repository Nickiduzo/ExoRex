using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] clouds;

    [SerializeField] private Transform firstPosition;
    [SerializeField] private Transform lastPosition;

    private List<GameObject> mainClouds;

    private void Awake()
    {
        InitializeClouds();
    }

    private void Update()
    {
        DeactivateCloud();
        
        foreach (var cloud in mainClouds)
        {
            if (!cloud.gameObject.activeSelf)
            {
                cloud.transform.position = RandomPosition();
                cloud.SetActive(true);
            }
        }
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

        for (int i = 0; i < 10; i++)
        {
            GameObject cloud = SpawnCloud();
            cloud.transform.position = new Vector3(UnityEngine.Random.Range(firstPosition.position.x, lastPosition.position.x), UnityEngine.Random.Range(1.5f, 3f));
            mainClouds.Add(cloud);
        }
    }
    private GameObject SpawnCloud()
    {
        int cloudIndex = UnityEngine.Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[cloudIndex], RandomPosition(), Quaternion.identity);
        cloud.transform.localScale = RandomScaleObject();

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
    
    private Vector3 RandomScaleObject()
    {
        float randomValue = Random.Range(0.2f, 1f);
        
        return new Vector3(randomValue,randomValue,randomValue);
    }
}
