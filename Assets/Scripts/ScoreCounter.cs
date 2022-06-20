using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int totalScore = 0;
    private int scoreMultiplier = 0;

    public int bottleCollected = 0;
    public int bottleInRow = 0;

    public ScoreCounter(int bottleCollected)
    {
        this.bottleCollected = bottleCollected;
    }
    private void Awake()
    {
        GlobalEventManager.onBottleCollected.AddListener(BottleCollected);
    }
    private void Start()
    {
        
    }

    internal void BottleCollected(int bottleCount)
    {

    }
}
