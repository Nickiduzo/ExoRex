using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NexitMaterial : MonoBehaviour
{
    private readonly int titaniumCost = 98;
    private readonly int ederiumCost = 60;
    private readonly int quartexCost = 25;

    private int currentTitaniumCost = 1;
    private int currentEderiumCost = 1;
    private int currentQuartexCost = 1;

    public int currentAmount = 1;
    private readonly int minAmount = 0;
    private readonly int maxAmount = 101;

    [SerializeField] private TextMeshProUGUI materialAmount;
    [SerializeField] private TextMeshProUGUI ederiumAmount;
    [SerializeField] private TextMeshProUGUI titaniumAmount;
    [SerializeField] private TextMeshProUGUI quartexAmount;

    [SerializeField] private Button buyButton;

    [SerializeField] private ShopPanel panel;

    [SerializeField] private ItemsConfig itemConfig;

    private readonly Color insufficientFundsColor = new Color(0.953f, 0.298f, 0.275f);
    private readonly Color sufficientFundsColor = new Color(0.275f, 0.953f, 0.725f);

    private void OnEnable()
    {
        InitializeComponents();
    }
    private void OnDisable()
    {
        InitializeComponents();
    }
    public void ProcureMaterial()
    {
        if (itemConfig.Ederium.amount >= currentEderiumCost &&
            itemConfig.Titanium.amount >= currentTitaniumCost)
        {
            itemConfig.Ederium.amount -= currentEderiumCost;
            itemConfig.Titanium.amount -= currentTitaniumCost;
            itemConfig.Quartex.amount -= currentQuartexCost;
            itemConfig.Nexit.amount += 1;
            panel.InitializeComponents();
        }
    }
    public void IncreaseAmount()
    {
        if (currentAmount + 1 < maxAmount)
        {
            currentAmount++;
            currentEderiumCost += ederiumCost;
            currentTitaniumCost += titaniumCost;
            currentQuartexCost += quartexCost;

            while (currentEderiumCost >= 100)
            {
                currentEderiumCost -= 100;
                currentTitaniumCost += 1;
            }

            UpdateMaterial();
        }
    }

    public void DecreaseAmount()
    {
        if (currentAmount - 1 > minAmount)
        {
            currentAmount--;
            currentTitaniumCost -= titaniumCost;
            currentEderiumCost -= ederiumCost;
            currentQuartexCost -= quartexCost;

            while (currentEderiumCost < 0)
            {
                currentEderiumCost += 100;
                currentTitaniumCost -= 1;
            }

            UpdateMaterial();
        }
    }
    private void UpdateMaterial()
    {
        materialAmount.text = currentAmount.ToString();
        ederiumAmount.text = currentEderiumCost.ToString();
        titaniumAmount.text = currentTitaniumCost.ToString();
        quartexAmount.text = currentQuartexCost.ToString();
        UpdateButtonColor();
    }
    private void UpdateButtonColor()
    {
        bool hasEnoughMaterials = itemConfig.Ederium.amount >= currentEderiumCost &&
                                  itemConfig.Titanium.amount >= currentTitaniumCost;

        ColorBlock colors = buyButton.colors;
        colors.normalColor = hasEnoughMaterials ? sufficientFundsColor : insufficientFundsColor;
        colors.highlightedColor = colors.normalColor;
        buyButton.colors = colors;
    }
    private void InitializeComponents()
    {
        currentAmount = 1;
        currentEderiumCost = ederiumCost;
        currentTitaniumCost = titaniumCost;
        currentQuartexCost = quartexCost;
        UpdateMaterial();
    }
}
