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
        recepDescription.text = recipe.description; 
    }

    private void InitializeComponents()
    {
        if (recepsManager.recipes.Count != 0)
        {
            currentRecipe = recepsManager.recipes[0];
            UpdateBuyButtonState();

            recipeName.text = currentRecipe.recipeName;
            novaciteAmount.text = currentRecipe.novaciteAmount.ToString();
            nexitAmount.text = currentRecipe.nexitAmount.ToString();
            quartexAmount.text = currentRecipe.quartexAmount.ToString();
            recepImage.sprite = currentRecipe.imageSprite;
            recepImage.preserveAspect = true;
            recepDescription.text = currentRecipe.description;
        }
    }

    private void UpdateBuyButtonState()
    {
        if (playerLevelData.currentLevel >= currentRecipe.characterLevel)
        {
            if (currentRecipe.isAvaible)
            {
                //buyButton.image.color = Color.white;
                buyButton.interactable = true;
                buttonLabel.text = "Buy";
            }
            else
            {
                //buyButton.image.color = Color.red;
                buyButton.interactable = false;
                buttonLabel.text = $"Requires Level {currentRecipe.characterLevel}";
            }
        }
        else
        {
            //buyButton.image.color = Color.gray;
            buyButton.interactable = false;
            buttonLabel.text = $"Requires Level {currentRecipe.characterLevel}";
        }
    }
}
