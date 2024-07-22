using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/Create new Items")]
public class ItemsConfig : ScriptableObject
{
	public Transform shopInventory;

    public Item Aderit;
    public Item Ederium;
    public Item Titanium;
    public Item Quartex;
    public Item Nexit;
    public Item Novacite;

    public void ConvertCurrency()
    {
        ConvertItem(Aderit, Ederium, 100);
        ConvertItem(Ederium, Titanium, 100);
    }

    private void ConvertItem(Item fromItem, Item toItem, int conversionRate)
    {
        if (fromItem.amount >= conversionRate)
        {
            int convertedAmount = fromItem.amount / conversionRate;
            fromItem.amount -= convertedAmount * conversionRate;
            toItem.amount += convertedAmount;
        }
    }
}
