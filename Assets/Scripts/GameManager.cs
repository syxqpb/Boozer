using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class GameManager : MonoBehaviour
{
    private int basePropCount = 6;
    public float baseTimePerProp = 2.0f;
    public int currentWave = 1;
    private Spawner _spawner;
    private int currentPropCount;
    public float currentTimer;
    public GameObject startButton;
    public GameOverPanelSC gameOverScreen;
    /// Старт игры методом через нажатие на прозрачную кнопку START, с отсчётом в 3 сек
    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        
    }
    private void Start()
    {
        
    }
    private void WaveStart(int currentWave)
    {
        currentPropCount = CalcPropCountPerWave();
        currentTimer = CalcTimerPropPerWave();
        Debug.Log($"{currentTimer}");
        _spawner.SpawnProps(currentPropCount, currentTimer);
    }

    private int CalcPropCountPerWave()
    {
        return (int)(basePropCount * (currentWave * 0.5f));
    }
    private float CalcTimerPropPerWave()
    {
        return baseTimePerProp * currentWave * 0.9f;
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        WaveStart(currentWave);
    }

    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverScreen.Show();
    }
}
