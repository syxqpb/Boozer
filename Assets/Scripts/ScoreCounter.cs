using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : PlayerController
{
    private int totalScore = 0;
    private int scoreMultiplier = 0;

    public int bottleCollected = 0;

    public ScoreCounter(int bottleCollected)
    {
        this.bottleCollected = bottleCollected;
    }

    private void Start()
    {
        GlobalEventManager.onBottleCollected.AddListener(BottleCollected);
    }

    internal void BottleCollected(int bottleCount)
    {

    }
}
