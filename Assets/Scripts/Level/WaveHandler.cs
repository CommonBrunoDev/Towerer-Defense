using UnityEngine;
public enum WaveState { Spawning, Waiting}
public class WaveHandler : MonoBehaviour
{
    public WaveSO currentWave;
    public WaveState state;
    public float waveTimer = 0;

    public int enemyAmount = 0;
    public int groupIndex = 0;

    public int totalEnemies = 0;

    private void Awake()
    {
        state = WaveState.Spawning;
        waveTimer = 10f;
    }
    private void Start()
    {

    }
    private void Update()
    {
        if (currentWave.startDelay > 0){ currentWave.startDelay -= Time.deltaTime; return;  }

        switch (state)
        {
            case WaveState.Spawning:
                if (waveTimer <= 0)
                {
                    if (enemyAmount >= currentWave.enemyGroups[groupIndex].amount)   //Check for next group
                    {
                        if (groupIndex >= currentWave.enemyGroups.Length) //Stops spawning enemies
                        { state = WaveState.Waiting; }
                        else //Passes to next group
                        {
                            enemyAmount = 0;
                            waveTimer = currentWave.enemyGroups[groupIndex].endDelay;
                            groupIndex++;
                        }
                    }
                    else
                    {
                        EnemyHandler.Instance.AddEnemy(currentWave.enemyGroups[groupIndex].enemyT);
                        enemyAmount++;
                        waveTimer = currentWave.enemyGroups[groupIndex].spawnDelay;
                    }
                }
                break;

            case WaveState.Waiting:
                if (enemyAmount <= 0)
                { GameManager.Instance.NextWave(); }
                break;
        }
    }
}
