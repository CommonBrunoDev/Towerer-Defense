using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/WaveSO", order = 1)]
public class WaveSO : ScriptableObject
{
    public EnemyGroupSO[] enemyGroups;
    public int enemyAmount;
    public float startDelay;
}