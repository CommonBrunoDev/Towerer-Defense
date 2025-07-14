using UnityEngine;

public enum GameState { Playing, Paused}
public class GameManager : MonoBehaviour
{
    public WaveHandler waveHandler;

    [SerializeField] float levelHealth = 100;
    [SerializeField] WaveSO[] waves;
    [SerializeField] private int waveIndex = 0;
    public GameState state;

    private static GameManager instance;
    public static GameManager Instance
    { get { return instance; } }

    private void Awake()
    {
        instance = this;
        SetWave(0);
    }
    public void TakeDamage(float damage)
    {
        levelHealth = Mathf.Clamp(levelHealth, 0, 100);
        if (levelHealth <= 0) { LoseGame(); }
    }
    public void SetWave(int index)
    {
        waveHandler.currentWave = waves[index];
        waveHandler.state = WaveState.Spawning;
    }
    public void NextWave()
    {
        waveIndex++;
        if (waveIndex >= waves.Length)
        { WinGame(); }
        else
        { SetWave(waveIndex); }
    }
    public void WinGame()
    {
        //Win screen,
        Debug.Log("Game Won");
    }
    public void LoseGame()
    {
        //Delete all enemies, ui for restart
        Debug.Log("Game Lost");
    }
}
