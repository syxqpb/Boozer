using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health_text, gameOver_text, startGame_text, wave_text;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameManager gameManager;


    private void Start()
    {
        int health = playerController.health;
        int waveNumber = gameManager.currentWave;
        CurrentHealthUI(health);
        CurrentWaveUI(waveNumber);
        gameOver_text.gameObject.SetActive(false);
        startGame_text.gameObject.SetActive(true);
        GlobalEventManager.onHealthChanged.AddListener(CurrentHealthUI);
        GlobalEventManager.onWaveEnded.AddListener(CurrentWaveUI);
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
}
