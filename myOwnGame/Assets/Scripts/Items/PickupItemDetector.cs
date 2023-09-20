using UnityEngine;

public class PickupItemDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickupItem pickupItem;
        if (collision.gameObject.TryGetComponent<IPickupItem>(out pickupItem))
        {
            pickupItem.Pickup();
        }
    }
}
