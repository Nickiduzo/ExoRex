using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void PickUp()
    {
        InventoryManager.Instance.AddItem(item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        PickUp();
    }
}
