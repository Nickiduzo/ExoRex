using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanel : MonoBehaviour
{
    [SerializeField] private RecepsManager recepsManager;

    [SerializeField] private GameObject readyRecipe;
    [SerializeField] private Transform recepWriter;
    [SerializeField] private LevelData levelData;

    private List<GameObject> recepList = new List<GameObject>();

    private List<GameObject> armorRecepsList = new List<GameObject>();
    private List<GameObject> implantRecepsList = new List<GameObject>();
    private List<GameObject> wheaponRecepsList = new List<GameObject>();

    private Dictionary<string, List<GameObject>> categoryRecepsList;

    public static Action<Stuff> ActionRecipeRequire;
    private void Awake()
    {
        InitializeButtons(recepsManager.recipesForCraft);
        InitializeCategoryDict();
        ShowRecipes("Armor");
    }

    private void InitializeCategoryDict()
    {
        categoryRecepsList = new Dictionary<string, List<GameObject>>()
        {
            { "Armor", armorRecepsList },
            { "Implant", implantRecepsList },
            { "Wheapon", wheaponRecepsList },
        };
    }

    private void InitializeButton(Recipe recipe)
    {
        GameObject newButton = Instantiate(readyRecipe, recepWriter);

        var recipeButton = newButton.transform.Find("NameOfRecipe").GetComponent<RecipeButton>();
        recepList.Add(newButton);

        if (recipeButton != null)
        {
            recipeButton.SetRecipeName(recipe);
            Button button = newButton.GetComponent<Button>();
            button.onClick.AddListener(recipeButton.OnButtonClick);
            recepList.Add(newButton);
            AddToCategoryList(recipe, newButton);
        }
        else
        {
            UnityEngine.Debug.Log("RecipeButton component not found in the new button prefab.");
        }
    }

    public void ShowRecipes(string which)
    {
        if (categoryRecepsList.ContainsKey(which))
        {
            ClearRecipeView();
            FullRecipeView(categoryRecepsList[which]);
        }
        else
        {
            UnityEngine.Debug.Log("Couldn't find recipe view");
        }
    }

    private void ClearRecipeView()
    {
        foreach (var recipeListExample in categoryRecepsList.Values)
        {
            foreach (var item in recipeListExample)
            {
                item.SetActive(false);
            }
        }
    }
    private void FullRecipeView(List<GameObject> recipes)
    {
        foreach (GameObject recipe in recipes)
        {
            recipe.SetActive(true);
        }
    }
    private void InitializeButtons(List<Recipe> recipes)
    {
        for (int i = 0; i < recipes.Count; i++)
        {
            InitializeButton(recipes[i]);
        }
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
                UnityEngine.Debug.Log("Unknown recipe category: " + recipe.type);
                break;
        }
    }
}
