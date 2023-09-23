using System.Collections.Generic;
using UnityEngine;

public class PickupItemDetector : MonoBehaviour
{
    private List<PickupItem> pickupList = new List<PickupItem>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PickupItem>(out PickupItem pickupItem))
        {
            pickupList.Add(pickupItem);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PickupItem>(out PickupItem pickupItem))
        {
            pickupList.Remove(pickupItem);
        }
    }


    public void PickupDetectedItems()
    {
        for(int i = 0; i < pickupList.Count; i++)
        {
            pickupList[i].Pickup();
        }

        pickupList.Clear();
    }
}
