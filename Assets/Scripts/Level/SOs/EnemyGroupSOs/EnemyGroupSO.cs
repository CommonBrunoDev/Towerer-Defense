using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/EnemyGroupSO", order = 1)]
public class EnemyGroupSO : ScriptableObject
{
    public GameObject enemyT;
    public int amount;
    public float spawnDelay;
    public float endDelay;
}