using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour, ISelectHandler
{
    PickupItemObject itemObject;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI amount;

 
    public void Initialize()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            itemIcon = transform.GetChild(i).GetComponent<Image>();
            if (itemIcon)
                break;
        }
        itemIcon.preserveAspect = true;
        amount = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void SetItemObject(PickupItemObject item)
    {
        itemObject = item;
    }
    public void SetAmount(int value)
    {
        amount.text = value.ToString();
    }
    public void UpdateItemIcon()
    {
        itemIcon.sprite = itemObject.Icon;
    }


    public void UpdateDescriptionData()
    {
    }
    public void OnSelect(BaseEventData eventData)
    {
        UpdateDescriptionData();
    }
}
