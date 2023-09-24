using UnityEngine;

public abstract class PickupItemObject : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public GameObject Model;
    [TextArea]
    public string Description;
}
