using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int totalScore = 0;
    public int bottleCollected = 0;

    public ScoreCounter(int bottleCollected)
    {
        this.bottleCollected = bottleCollected;
    }

    private void Awake()
    {
    }
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
