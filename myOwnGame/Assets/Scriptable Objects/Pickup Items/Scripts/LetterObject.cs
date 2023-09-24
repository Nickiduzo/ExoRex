using UnityEngine;

[CreateAssetMenu(fileName = "New Letter Object", menuName = "Inventory System/Pickup Items/Letter")]
public class LetterObject : PickupItemObject
{
    [Header("Text Parameters")]
    public Font Font;
    public int FontSize = 12;
    
    [Header("Content")]
    public string Header;
    [TextArea]
    public string ReadableContent;

}
