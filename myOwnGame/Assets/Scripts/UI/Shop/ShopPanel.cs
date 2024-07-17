using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public ItemsConfig config;

    [SerializeField] private GameObject[] panels;

    [SerializeField] private TextMeshProUGUI aderit;
    [SerializeField] private TextMeshProUGUI ederium;
    [SerializeField] private TextMeshProUGUI titanium;
    [SerializeField] private TextMeshProUGUI quartex;
    [SerializeField] private TextMeshProUGUI nexit;
    [SerializeField] private TextMeshProUGUI novacite;

    private void OnEnable()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        config.ConvertCurrency();
        aderit.text = config.Aderit.amount.ToString();
        ederium.text = config.Ederium.amount.ToString();
        titanium.text = config.Titanium.amount.ToString();
        quartex.text = config.Quartex.amount.ToString();
        nexit.text = config.Nexit.amount.ToString();
        novacite.text = config.Novacite.amount.ToString();
    }
    private void HideElements(string panelName)
    {
        foreach (GameObject panel in panels)
        {
            if (panel.gameObject.name != panelName)
            {
                panel.SetActive(false);
            }
            else if (panel.gameObject.name == panelName)
            {
                if (!panel.activeInHierarchy)
                {
                    panel.SetActive(true);
                }
            }
        }
    }

    public void SwitchPanel(string panelName)
    {
        HideElements(panelName);
    }

    public void GetEderium()
    {
        if (config.Aderit.amount - 100 > 0)
        {
            config.Aderit.amount -= 100;
            config.Ederium.amount += 1;
            InitializeComponents();
        }
    }

    public void GetAderit()
    {
        if (config.Ederium.amount - 1 > 0)
        {
            config.Ederium.amount -= 1;
            config.Aderit.amount += 100;
            InitializeComponents();
        }
    }
    public void GetTitanium()
    {
        if (config.Ederium.amount - 100 > 0)
        {
            config.Ederium.amount -= 100;
            config.Titanium.amount += 1;
            InitializeComponents();
        }
    }
    public void GetNexit()
    {
        if (IsNexit())
        {
            config.Aderit.amount -= 25;
            config.Ederium.amount -= 15;
            config.Titanium.amount -= 10;
            config.Nexit.amount += 1;
            InitializeComponents();
        }
    }

    private bool IsNexit()
    {
        return (config.Aderit.amount > 25 && config.Ederium.amount > 15 && config.Titanium.amount > 10);
    }
}
