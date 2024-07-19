using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecepsPanel : MonoBehaviour
{
    //private List<GameObject> receps;
    [SerializeField] private Transform recepsPanel;
    [SerializeField] private RecepsManager recepsManager;
    [SerializeField] private GameObject pattern;
    private void OnEnable()
    {
        for (int i = 0; i < recepsManager.recipes.Count; i++)
        {
            GameObject recepExample = Instantiate(pattern, recepsPanel);

        }
    }
}
