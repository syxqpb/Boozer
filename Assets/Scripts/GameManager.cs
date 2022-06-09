using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private int basePropCount = 6;
    [SerializeField] private float baseTimePerProp = 2.0f;
    public int currentWave = 1;
    private Spawner _spawner;
    private int currentPropCount;
    [SerializeField] private float currentTimer;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameOverPanelSC gameOverScreen;
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
