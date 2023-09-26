using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public PickupItemObject Item;
    [SerializeField] private int amount = 1;
    
    public void Pickup()
    {
        InventorySystem.Instance.Add(Item, amount);
        Destroy(gameObject);
    }
}
