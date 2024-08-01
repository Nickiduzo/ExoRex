using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Armor", menuName ="Stuff/Armor")]
public class Armor : ScriptableObject
{
    public string armorName;
    public int armorStat;

    public Sprite armorImage;
}
