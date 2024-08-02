using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Wheapon", menuName ="Stuff/Wheapon")]
public class Wheapon : ScriptableObject
{
    public string wheaponName;
    public int damage;

    public Sprite wheaponImage;
    public string description;
}
