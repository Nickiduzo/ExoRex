using TMPro;
using UnityEngine;

public class Material : MonoBehaviour
{
    private string nameOfMaterial = "Quartex";
    private int titaniumCost = 52; // usual price
    private int ederiumCost = 20; // usual price

    private int currentTitaniumCost = 1;
    private int currentEderiumCost = 1;

    public int currentAmount = 1;
    public int minAmount = 1;
    public int maxAmount = 100;

    [SerializeField] private TextMeshProUGUI materialAmount;
    [SerializeField] private TextMeshProUGUI ederiumAmount;
    [SerializeField] private TextMeshProUGUI titaniumAmount;

    private void OnEnable()
    {
        currentAmount = minAmount;
        currentEderiumCost = ederiumCost;
        currentTitaniumCost = titaniumCost;
        ederiumAmount.text = currentEderiumCost.ToString();
        titaniumAmount.text = currentTitaniumCost.ToString();
    }

    public void DecreaseAmount()
    {
        if (!(currentAmount - 1 == minAmount))
        {
            currentAmount--;
            titaniumCost = titaniumCost * currentAmount;
            ederiumCost = ederiumCost * currentAmount;
        }
    }   
    
    public void IncreaseAmount()
    {
        
    }

    private void UpdateMaterial()
    {

    }
}
