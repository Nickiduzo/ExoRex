using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData", menuName ="PlayerData/Player")]
public class PlayerData : ScriptableObject
{
    public string nickname;
    public string password;

    public int currentLevel;

    public int playerHP;
    public int playerArmor;

    public float playerSpeed;
    public float playerDamage;

    public float playerJumpForce;

    public Armor currentArmor;
    public Implant currentImplant;
    public Wheapon currentWheapon;
}
