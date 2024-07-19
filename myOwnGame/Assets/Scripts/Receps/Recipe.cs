using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipes/Recipe")]
public class Recipe : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private RecipeType type;
    [SerializeField] private int characterLevel;
    [SerializeField] private float dropChance; // static dropChance, but with changing level dropChance increases on 2 %
    [SerializeField] private ItemType[] types;
    [SerializeField] private int[] amountTypes;

    private bool isAvaible = false;
}
