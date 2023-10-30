using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void PickUp()
    {
        InventoryManager.Instance.AddItem(item);
        Destroy(gameObject);
    }

    private void Update()
    {
        float pickupRadius = 0.2f;
        float playerX = player.transform.position.x;
        float itemX = gameObject.transform.position.x;

        if (Mathf.Abs(playerX - itemX) <= pickupRadius)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }
    }
}
