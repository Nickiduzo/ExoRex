using TMPro;
using UnityEngine;

public class RecipePickup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeName;

    public Recipe recipe;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ShowLevelRecipes();
        SetRecipeName();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InventoryManager.Instance.CollectRecep(recipe);
            Destroy(gameObject);
        }
    }

    public void SetRecipe(Recipe newRecipe)
    {
        recipe = newRecipe;
    }

    private void SetRecipeName()
    {
        recipeName.text = recipe.recipeName;
    }
    private void ShowLevelRecipes()
    {
        if (recipe.characterLevel < 35)
        {
            spriteRenderer.color = Color.gray;
            recipeName.color = Color.gray;
        }
        else if (recipe.characterLevel > 35 && recipe.characterLevel < 70)
        {
            spriteRenderer.color = Color.green;
            recipeName.color = Color.green;
        }
        else if (recipe.characterLevel > 69)
        {
            spriteRenderer.color = Color.yellow;
            recipeName.color = Color.yellow;
        }
    }
}
