using UnityEngine;

public class ToolIntegration : MonoBehaviour
{
    [SerializeField] private GameObject boer;
    [SerializeField] private GameObject player;
    private InventoryManager inventory;
    private void Start()
    {
        inventory = InventoryManager.Instance;
    }
    private void UseBoer()
    {
        var BoerEquip = player.transform.Find("Boer");
        if (IsContainItem()) boer.SetActive(true);
    }
    private void DeuseBoer()
    {
        if (IsContainItem())
        {
            boer.SetActive(false);
        }
    }
    private bool IsContainItem()
    {
        foreach (Item item in inventory.items)
        {
            if (item.name == "Boer")
            {
                return true;
            }
        }
        return false;
    }
    
}
