using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TokenPanel : MonoBehaviour
{
    [SerializeField] private Token token;
    [SerializeField] private ItemsConfig itemConfig;

    [SerializeField] private TextMeshProUGUI tokenAmountText;
    [SerializeField] private Button buyTokenButton;
    [SerializeField] private ShopPanel shopPanel;

    private readonly Color insufficientFundsColor = new Color(0.953f, 0.298f, 0.275f); // #F34C46
    private readonly Color sufficientFundsColor = new Color(0.275f, 0.953f, 0.725f); // #46F3B9

    private readonly int requiredAderit = 80;
    private readonly int requiredEderium = 50;
    private readonly int requiredTitanium = 10;
    private void Start()
    {
        UpdateUI();
        UpdateButtonColor();
    }

    public void BuyToken()
    {
        if (CanAffordToken())
        {
            DeductCosts();
            UpdateUI();
            UpdateButtonColor();
        }
    }

    private bool CanAffordToken()
    {
        int availableAderit = itemConfig.Aderit.amount;
        int availableEderium = itemConfig.Ederium.amount;
        int availableTitanium = itemConfig.Titanium.amount;

        if (availableAderit >= requiredAderit && availableEderium >= requiredEderium && availableTitanium >= requiredTitanium)
        {
            return true;
        }
        else if (availableTitanium > requiredTitanium)
        {
            return true;
        }
        return false;
    }

    private void DeductCosts()
    {
        int avaibleAderit = itemConfig.Aderit.amount;
        int avaibleEderium = itemConfig.Ederium.amount;
        int avaibleTitanium = itemConfig.Titanium.amount;

        if (avaibleEderium < requiredEderium)
        {
            //avaibleEderium += 100;
            //avaibleTitanium -= 1;

            itemConfig.Ederium.amount += 100;
            itemConfig.Titanium.amount -= 1;
        }

        if (avaibleAderit < requiredAderit)
        {
            //avaibleAderit += 100;
            //avaibleEderium -= 1;

            itemConfig.Aderit.amount += 100;
            itemConfig.Ederium.amount -= 1;
        }

        if (itemConfig.Aderit.amount >= requiredAderit &&
            itemConfig.Ederium.amount >= requiredEderium &&
            itemConfig.Titanium.amount >= requiredTitanium)
        {
            itemConfig.Aderit.amount -= requiredAderit;
            itemConfig.Ederium.amount -= requiredEderium;
            itemConfig.Titanium.amount -= requiredTitanium;
            token.amount++;

        }
    }

    private void UpdateUI()
    {
        tokenAmountText.text = token.amount.ToString();
        shopPanel.InitializeComponents();
    }

    private void UpdateButtonColor()
    {
        bool canAffordToken = CanAffordToken();

        ColorBlock colors = buyTokenButton.colors;
        colors.normalColor = canAffordToken ? sufficientFundsColor : insufficientFundsColor;
        colors.highlightedColor = colors.normalColor;
        colors.pressedColor = colors.normalColor;
        colors.selectedColor = colors.normalColor;
        buyTokenButton.colors = colors;
    }
}
