using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health_text, gameOver_text, startGame_text, wave_text, score_text, scoreFinal_text, highscore_text;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ScoreCounter score;


    private void Start()
    {
        int health = playerController.health;
        int waveNumber = gameManager.currentWave;
        int scoreValue = score.totalScore;
        int strike = playerController.collectedBottles;
        CurrentHealthUI(health);
        CurrentWaveUI(waveNumber);
        CurrentScoreUI(scoreValue, strike);
        GameOverScoreUI(scoreValue, strike);  // GameOverScoreUI and
        HighScoreUI(scoreValue, strike);      // HighScoreUI now work just as plug
        gameOver_text.gameObject.SetActive(false);
        startGame_text.gameObject.SetActive(true);
        GlobalEventManager.onHealthChanged.AddListener(CurrentHealthUI);
        GlobalEventManager.onWaveEnded.AddListener(CurrentWaveUI);
        GlobalEventManager.onBottleCollected.AddListener(CurrentScoreUI);
        GlobalEventManager.onBottleCollected.AddListener(GameOverScoreUI);
        GlobalEventManager.onBottleCollected.AddListener(HighScoreUI);
    }

    private void CurrentHealthUI(int health)
    {
        health_text.text = $"HEALTH: {playerController.health}";
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
        highscore_text.text = $"NEW HIGHSCORE: {score.totalScore}"; //REWORK NEEDED
    }


}
