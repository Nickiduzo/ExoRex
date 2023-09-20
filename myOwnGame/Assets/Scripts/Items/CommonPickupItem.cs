using UnityEngine;

public class CommonPickupItem : MonoBehaviour, IPickupItem
{
    public void Pickup()
    {
        Debug.Log("You just pick up an item");
    }
}
