using UnityEngine;

public abstract class UpgradeItemObject : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    [TextArea]
    public string Description;
}
