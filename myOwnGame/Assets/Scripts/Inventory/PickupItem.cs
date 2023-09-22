using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public ItemData data;
    
    public void Pickup()
    {
        Inventory.Instance.Add(data);
        Destroy(gameObject);
    }
}
