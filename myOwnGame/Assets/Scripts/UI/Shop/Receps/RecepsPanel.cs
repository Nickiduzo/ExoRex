using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecepsPanel : MonoBehaviour
{
    [Header("Receps viewer")]
    [SerializeField] private GameObject recepButton; // main button which represent recep
    [SerializeField] private Transform recepWriter; // panel, where show all receps
    [SerializeField] private LevelData levelData;

    [Header("Filer")]
    [SerializeField] private TMP_InputField searchInputField;

    [SerializeField] private RecepsManager recepsManager;
    private List<GameObject> recepsList = new List<GameObject>();

    private List<GameObject> armorRecepsList = new List<GameObject>();
    private List<GameObject> implantRecepsList = new List<GameObject>();
    private List<GameObject> wheaponRecepsList = new List<GameObject>();

    private Dictionary<string, List<GameObject>> categoryRecepsList;

    public static Action<Recipe> ActionRecepRequire;
    private void Start()
    {
        InitializeButtons(recepsManager.recipes);
        InitializeCategoryDict();
        searchInputField.onValueChanged.AddListener(OnSearchInputChanged);
    }
  
    public void OnButtonClick()
    { 
        AudioManager.Instance.PlaySound("ClickButton");      
    }

    public void OnButtonSelect()
    {
        AudioManager.Instance.PlaySound("SelectButton");
    }
 
    public void ShowReceps(string which)
    {
        if (categoryRecepsList.ContainsKey(which))
        {
            ClearRecepView();
            FullRecepView(categoryRecepsList[which]);
        }
        else
        {
            Debug.Log("Couldn't find recap view");
        }
    }
    private void ClearRecepView()
    {
        foreach (var recepList in categoryRecepsList.Values)
        {
            foreach (var item in recepList)
            {
                item.SetActive(false);
            }
        }
    }

    private void FullRecepView(List<GameObject> receps)
    {
        foreach(GameObject item in receps)
        {
            item.SetActive(true);
        }
    }
    private void InitializeButton(Recipe recipe)
    {
        GameObject newButton = Instantiate(recepButton, recepWriter);
        
        var recipeButton = newButton.transform.Find("Title").GetComponent<RecipeButton>();
        recepsList.Add(newButton);
        
        if (recepButton != null)
        {
            recipeButton.SetRecipeName(recipe);
            Button button = newButton.GetComponent<Button>();
            button.onClick.AddListener(recipeButton.OnButtonClick);
            recepsList.Add(newButton);
            AddToCategoryList(recipe, newButton);
        }
        else
        {
            Debug.Log("RecipeButton component not found in the new button prefab");
        }
    }

    private void InitializeButtons(List<Recipe> recipes)
    {
        for (int i = 0; i < recipes.Count; i++)
        {
            InitializeButton(recipes[i]);
        }
    }

    private void InitializeCategoryDict()
    {
        categoryRecepsList = new Dictionary<string, List<GameObject>>()
        {
            { "All", recepsList },
            { "Armor", armorRecepsList },
            { "Implant", implantRecepsList },
            { "Wheapon", wheaponRecepsList }
        };
    }

    private void AddToCategoryList(Recipe recipe, GameObject button)
    {
        switch (recipe.type)
        {
            case RecipeType.Armor:
                armorRecepsList.Add(button);
                break;
            case RecipeType.Implant:
                implantRecepsList.Add(button);
                break;
            case RecipeType.Wheapon:
                wheaponRecepsList.Add(button);
                break;
            default:
                Debug.Log("Unknown recipe category: " + recipe.type);
                break;
        }
    }

    private void OnSearchInputChanged(string searchTerm)
    {
        searchTerm = searchTerm.ToLower();
        bool anyMatch = false;

        foreach (var recep in recepsList)
        {
            RecipeButton recipeButton = recep.transform.Find("Title").GetComponent<RecipeButton>();
            if (recipeButton != null)
            {
                string recipeName = recipeButton.buttonText.text.ToLower();
                bool isShouldShow = recipeName.Contains(searchTerm);

                recep.SetActive(isShouldShow);

                if (isShouldShow)
                {
                    Debug.Log("Math found: " + recipeName);
                    anyMatch = true;
                }
            }
            else
            {
                Debug.LogWarning("RecipeButton component not found on: " + recep.name);
            }
        }

        if (!anyMatch)
        {
            Debug.Log("No matches found");
        }
    }
}
