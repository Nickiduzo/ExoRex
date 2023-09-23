using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public GameObject Model;
    [TextArea]
    public string Description;
}
