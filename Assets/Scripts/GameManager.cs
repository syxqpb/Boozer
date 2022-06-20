using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Spawner))]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private int basePropCount = 6;
    [SerializeField] private float baseTimePerProp = 2.0f;
    [SerializeField] private float currentTimer;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameOverPanelSC gameOverScreen;
    public int currentWave = 1;
    private Spawner _spawner;
    private int currentPropCount;
    private int collectedBottlesCountInWave = 0;
    private int brokenBottlesCountInWave = 0;

    private ProgressLoader<Progression> loader;
    public ProgressLoader<Progression> Progress { get { return loader; } }

    /// Starting the game by pressing the transparent START button, with a countdown of 3 seconds
    private void Awake()
    {
        instance = this;
        loader = new ProgressLoader<Progression>(new Progression());
        _spawner = GetComponent<Spawner>();
        GlobalEventManager.onGameOver.AddListener(GameOver);
        
    }
    private void WaveStart(int currentWave)
    {
        currentPropCount = CalcPropCountPerWave(currentWave);
        currentTimer = CalcTimerPropPerWave(currentWave);
        _spawner.SpawnProps(currentPropCount, currentTimer);
    }

    private int CalcPropCountPerWave(int currentWave)
    {
        if (currentWave == 1)
            return basePropCount;
        else return (int)((currentWave % 3 != 0) ? basePropCount + (currentWave * 0.5f) : (basePropCount + (currentWave * 0.8f)));
    }
    private float CalcTimerPropPerWave(int currentWave)
    {
        return (float)((currentWave % 3 != 0) ? baseTimePerProp + (currentWave / 1.1f) : baseTimePerProp + (currentWave / 1.3f));
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        WaveStart(currentWave);
    }

    public void NextWave()
    {
        WaveStart(currentWave);
    }

    public void GameOver()
    {    
        gameOverScreen.Open();
    }

    public void Reset()
    {
        StopAllCoroutines();    
        SceneManager.LoadScene(GameLoader.GAME_SCENE);
        Time.timeScale = 1.0f;
    }

    public void CalcCollectedBottlesPerWave(int collectedBottlesCountInWave)
    {
        collectedBottlesCountInWave++;
    }
    public void CalcBrokenBottlesPerWave(int brokenBottlesCountInWave)
    {
        brokenBottlesCountInWave++;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {

        }
    }

}
