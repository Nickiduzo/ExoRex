using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Stuff", menuName = "PlayerData/Stuff")]
public class Stuff : ScriptableObject
{
    public List<Armor> armor;
    public List<Wheapon> arsenal;
    public List<Implant> labaratory;
}
