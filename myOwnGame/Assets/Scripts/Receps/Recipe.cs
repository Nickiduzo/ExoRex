using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipes/Recipe")]
public class Recipe : ScriptableObject
{
    public string recipeName;
    public RecipeType type; // type
    public int characterLevel; // required character level
    public float dropChance; // static dropChance, but with changing level dropChance increases on 2 %

    public int novaciteAmount;
    public int nexitAmount;
    public int quartexAmount;

    public Sprite imageSprite; // image of item
    public string description;

    public string GetFormatedDescription()
    {
        return TextFormater.FormatDescription(description);
    }
}
