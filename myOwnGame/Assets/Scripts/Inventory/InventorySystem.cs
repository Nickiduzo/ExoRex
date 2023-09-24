using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;
    [SerializeField] private InventoryObject inventoryObject;
    [SerializeField] private Transform inventoryContent;
    [SerializeField] private GameObject inventoryItemPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(PickupItemObject item, int amount)
    {
        bool hasItem = false;

        for (int i = 0; i < inventoryObject.Container.Count; i++)
        {
            if (inventoryObject.Container[i].Item == item)
            {
                inventoryObject.Container[i].AddAmount(amount);

                bool isUIItemFound = false;
                for(int j = 0; j < inventoryContent.childCount; j++)
                {
                    Transform temp = inventoryContent.GetChild(j);
                    if(temp.name == item.Name)
                    {
                        TextMeshProUGUI text = temp.GetComponentInChildren<TextMeshProUGUI>();
                        text.text = inventoryObject.Container[i].Amount.ToString();
                        isUIItemFound = true;
                        break;
                    }
                }
                if (!isUIItemFound)
                {
                    GameObject addedItem = Instantiate(inventoryItemPrefab, inventoryContent);
                    addedItem.name = item.Name;
                    Image image = addedItem.GetComponentInChildren<Image>();
                    image.sprite = item.Icon;
                    image.preserveAspect = true;
                    TextMeshProUGUI text = addedItem.GetComponentInChildren<TextMeshProUGUI>();
                    text.text = inventoryObject.Container[i].Amount.ToString();
                }

                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            inventoryObject.Container.Add(new InventorySlot(item, amount));
            GameObject addedItem = Instantiate(inventoryItemPrefab, inventoryContent);
            addedItem.name = item.Name;
            Image image = addedItem.GetComponentInChildren<Image>();
            image.sprite = item.Icon;
            image.preserveAspect = true;
            TextMeshProUGUI text = addedItem.GetComponentInChildren<TextMeshProUGUI>();
            text.text = amount.ToString();
        }
    }
    public void Decrease(PickupItemObject item)
    {
        
    }

    private void OnApplicationQuit()
    {
        inventoryObject?.Container.Clear();
    }
}
