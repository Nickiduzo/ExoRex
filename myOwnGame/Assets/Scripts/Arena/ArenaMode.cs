using UnityEngine;

[System.Serializable]
public class ArenaMode
{
    public float startDelay;
    public float spawnDelay;
    public float patrolSpeed;
    public float chaseSpeed;
    public float bossPatrolSpeed;
    public float bossChaseSpeed;

    [HideInInspector]
    public int highScore;
}