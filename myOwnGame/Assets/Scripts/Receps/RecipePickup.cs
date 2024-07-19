using UnityEngine;

public class RecipePickup : MonoBehaviour
{
    [SerializeField] private Recipe recipe;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InventoryManager.Instance.CollectRecep(recipe);
            Destroy(gameObject);
        }
    }
}
