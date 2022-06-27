using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int totalScore = 0;
    public int bottleCollected = 0;
    
    private void Start()
    {
        GlobalEventManager.onBottleCollected.AddListener(BottleCollected);
    }
    internal void BottleCollected(int value , int bottleCount)
    {
        AddScore(value, bottleCount);
    }
    public void AddScore(int value, int strike = 1)
    {
        totalScore += value * strike;
    }
}
