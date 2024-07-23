using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Receps", menuName = "Recipes/Catalog")]
public class RecepsManager : ScriptableObject
{
    public List<Recipe> recipes;

    public bool IsAvaibleRecep(Recipe recipe)
    {
        return recipe.isAvaible;
    }
}