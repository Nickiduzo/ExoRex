using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecepRequire : MonoBehaviour
{
    [Header("Description")]
    [SerializeField] private TextMeshProUGUI recepDescription;
    [SerializeField] private TextMeshProUGUI recipeName;

    [Header("RequiredMaterial")]
    [SerializeField] private TextMeshProUGUI novaciteAmount;
    [SerializeField] private TextMeshProUGUI nexitAmount;
    [SerializeField] private TextMeshProUGUI quartexAmount;

    [SerializeField] private Image recepImage;

    [SerializeField] private RecepsManager recepsManager;
    [SerializeField] private ItemsConfig materials;

    [Header("Buy/Sell")]
    [SerializeField] private Button buyButton;
    [SerializeField] private TextMeshProUGUI buttonLabel;

    [SerializeField] private LevelData playerLevelData;

    private Recipe currentRecipe;
    private void Start()
    {
        InitializeComponents();
    }
    private void OnEnable()
    {
        RecepsPanel.ActionRecepRequire += ShowRecepInfo; 
    }

    private void OnDisable()
    {
        RecepsPanel.ActionRecepRequire -= ShowRecepInfo;
    }

    public void BuyRecipe()
    {
        if (IsAvaible() && !recepsManager.recipesForShop.Contains(currentRecipe))
        {
            DecreaseMaterials();
            recepsManager.recipesForShop.Add(currentRecipe);
        }
    }

    public void CreateRecipeItem()
    {
        if (IsAvaible() && !recepsManager.recipesForCraft.Contains(currentRecipe)) 
        {
            DecreaseMaterials();
            recepsManager.recipesForCraft.Add(currentRecipe);
        }
    }
    
    private void DecreaseMaterials()
    {
        materials.Novacite.amount -= currentRecipe.novaciteAmount;
        materials.Nexit.amount -= currentRecipe.nexitAmount;
        materials.Quartex.amount -= currentRecipe.quartexAmount;
    }
    private bool IsAvaible()
    {
        return (playerLevelData.currentLevel >= currentRecipe.characterLevel &&
            materials.Novacite.amount >= currentRecipe.novaciteAmount &&
            materials.Nexit.amount >= currentRecipe.nexitAmount &&
            materials.Quartex.amount >= currentRecipe.quartexAmount);
    }
    private void ShowRecepInfo(Recipe recipe)
    {
        currentRecipe = recipe;
        UpdateBuyButtonState();

        recipeName.text = recipe.recipeName;
        novaciteAmount.text = recipe.novaciteAmount.ToString();
        nexitAmount.text = recipe.nexitAmount.ToString();
        quartexAmount.text = recipe.quartexAmount.ToString();
        recepImage.sprite = recipe.imageSprite;
        recepImage.preserveAspect = true;
        recepDescription.text = recipe.GetFormatedDescription(); 
    }

    private void InitializeComponents()
    {
        if (recepsManager.allGameRecipes.Count != 0)
        {
            currentRecipe = recepsManager.allGameRecipes[0];
            UpdateBuyButtonState();

            recipeName.text = currentRecipe.recipeName;
            novaciteAmount.text = currentRecipe.novaciteAmount.ToString();
            nexitAmount.text = currentRecipe.nexitAmount.ToString();
            quartexAmount.text = currentRecipe.quartexAmount.ToString();
            recepImage.sprite = currentRecipe.imageSprite;
            recepImage.preserveAspect = true;
            recepDescription.text = currentRecipe.GetFormatedDescription();
        }
    }

    private void UpdateBuyButtonState()
    {
        if (playerLevelData.currentLevel >= currentRecipe.characterLevel)
        {
            if (!NotEnoughMaterials())
            {
                buyButton.interactable = false;
                buttonLabel.text = $"Not enough materials";
            }
            buyButton.interactable = true;
            buttonLabel.text = "Buy";
        }
        else
        {
            //buyButton.image.color = Color.gray;
            buyButton.interactable = false;
            buttonLabel.text = $"Requires Level {currentRecipe.characterLevel}";
        }
    }

    private bool NotEnoughMaterials()
    {
        return materials.Novacite.amount >= currentRecipe.novaciteAmount &&
               materials.Nexit.amount >= currentRecipe.nexitAmount &&
               materials.Quartex.amount >= currentRecipe.quartexAmount;
    }
}
