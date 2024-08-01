using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="PlayerData", menuName ="PlayerData/Player")]
public class PlayerData : ScriptableObject
{
    public int playerHP;
    public int playerArmor;

    public float playerSpeed;
    public float playerDamage;

    public float playerJumpForce;

    //public Dictionary<string, Perk> characterPerks;
}
