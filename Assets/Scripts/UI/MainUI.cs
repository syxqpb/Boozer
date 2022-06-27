using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health_text;
    [SerializeField] private TextMeshProUGUI gameOver_text;
    [SerializeField] private TextMeshProUGUI startGame_text;
    [SerializeField] private TextMeshProUGUI wave_text;
    [SerializeField] private TextMeshProUGUI score_text;
    [SerializeField] private TextMeshProUGUI scoreFinal_text; 
    [SerializeField] private TextMeshProUGUI   highscore_text;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ScoreCounter score;
    [SerializeField] private HealthText _healthText;


    private void Start()
    {
        int health = playerController.health;
        int waveNumber = gameManager.currentWave;
        int scoreValue = playerController.ScoreCounter.totalScore;
        int strike = playerController.collectedBottles;
        GlobalEventManager.onHealthChanged.AddListener(CurrentHealthUI);
        GlobalEventManager.onWaveEnded.AddListener(CurrentWaveUI);
        GlobalEventManager.onBottleCollected.AddListener(CurrentScoreUI);
        GlobalEventManager.onBottleCollected.AddListener(GameOverScoreUI);
        GlobalEventManager.onBottleCollected.AddListener(HighScoreUI);
        CurrentHealthUI(health, scoreValue);
        CurrentWaveUI(waveNumber);
        CurrentScoreUI(scoreValue, strike);
        GameOverScoreUI(scoreValue, strike);  // GameOverScoreUI and
        HighScoreUI(scoreValue, strike);      // HighScoreUI now work just as plug
        gameOver_text.gameObject.SetActive(false);
        startGame_text.gameObject.SetActive(true);
    }

    private void CurrentHealthUI(int health, int score)
    {
        Debug.Log(playerController.health);
        _healthText.UpdateValues(playerController.health);
        //health_text.text = $"HEALTH: {}";
        if (playerController.health == 0)
        {
            gameOver_text.gameObject.SetActive(true);
        }
    }

    private void CurrentWaveUI(int waveNumber)
    {
        wave_text.text = $"WAVE: {gameManager.currentWave}";
    }

    private void CurrentScoreUI(int totalScore, int strike)
    {
        score_text.text = $"SCORE: {score.totalScore}";
    }
    
    private void GameOverScoreUI(int totalScore, int strike)
    {
        scoreFinal_text.text = $"SCORE: {score.totalScore}";
    }
    private void HighScoreUI(int totalScore, int strike)
    {
        if (playerController.ScoreCounter.totalScore > PlayerPrefs.GetInt("HighScore"))
        {
            totalScore = PlayerPrefs.GetInt("HighScore");
            highscore_text.text = $"NEW HIGHSCORE: {totalScore}";

        }
        else
        {
            totalScore = PlayerPrefs.GetInt("HighScore");
            highscore_text.text = $"HIGHSCORE: {totalScore}";
        }
    }


}
