using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Spawner))]
public class GameManager : MonoBehaviour
{
    private int basePropCount = 6;
    public float baseTimePerProp = 2f;
    public int currentWave = 3;
    private Spawner _spawner;
    private int currentPropCount;
    public float currentTimer;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }
    private void Start()
    {
        WaveStart(1);
    }
    private void WaveStart(int currentWave)
    {
        currentPropCount = CalcPropCountPerWave();
        currentTimer = CalcTimerPropPerWave();
        Debug.Log(currentTimer);
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
}
