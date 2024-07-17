using TMPro;
using UnityEngine;

public class CoinPanel : MonoBehaviour
{
    [SerializeField] private ItemsConfig config;

    [SerializeField] private TextMeshProUGUI aderitAmount;
    [SerializeField] private TextMeshProUGUI ederiumAmount;
    [SerializeField] private TextMeshProUGUI titaniumAmount;
    private void OnEnable()
    {
        InitializeComponents();
    }

    private void Update()
    {
        config.ConvertCurrency();
        InitializeComponents();
    }
    private void InitializeComponents()
    {
        aderitAmount.text = config.Aderit.amount.ToString();
        ederiumAmount.text = config.Ederium.amount.ToString();
        titaniumAmount.text = config.Titanium.amount.ToString();
    }
}
