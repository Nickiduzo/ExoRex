using TMPro;
using UnityEngine;

public class RecipeButton : MonoBehaviour
{
    public TextMeshProUGUI buttonText;

    private Recipe currentRecipe;

    public void SetRecipeName(Recipe recipe)
    {
        currentRecipe = recipe;
        buttonText.text = recipe.recipeName;
    }

    public void OnButtonClick()
    {
        if (currentRecipe != null)
        {
            RecepsPanel.ActionRecepRequire?.Invoke(currentRecipe);
        }
    }
}
