using UnityEngine;


[CreateAssetMenu(fileName = "MineLevel", menuName = "Configs/MineLevel")]
public class MineConfig : ScriptableObject
{
    [SerializeField] private Cloud[] clouds;

    public Cloud[] Clouds => clouds;
}
