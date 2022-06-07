using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI health_text, gameOver_text, startGame_text, wave_text;
    public PlayerController playerController;
    public GameManager gameManager;

    private void Awake()
    {
        
    }

    private void Start()
    {
        gameOver_text.gameObject.SetActive(false);
        startGame_text.gameObject.SetActive(true);
    }

    private void Update()
    {
        CurrentHealthUI(); 
        CurrentWaveUI();
    }

    private void CurrentHealthUI()
    {
        health_text.text = $"HEALTH: {playerController.health}";
        if (playerController.health == 0)
        {
            gameOver_text.gameObject.SetActive(true);
        }
    }

    private void CurrentWaveUI()
    {
        wave_text.text = $"WAVE: {gameManager.currentWave}";
    }
}
