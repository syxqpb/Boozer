using UnityEngine.Events;

[System.Serializable]
internal class GlobalEventManager : UnityEvent<GlobalEventManager>
{
    public static UnityEvent<int> onWaveEnded = new UnityEvent<int>();
    public static UnityEvent<int,int> onBottleCollected = new UnityEvent<int,int>();
    public static UnityEvent<int> onBottleBroken = new UnityEvent<int>();
    public static UnityEvent<int> onHealthChanged = new UnityEvent<int>();
    public static UnityEvent onGameOver = new UnityEvent();
    public static void SendWaveEnded(int waveCount)
    {
        onWaveEnded.Invoke(waveCount);
    }
    public static void SendHealthChanged(int health)
    {
        onHealthChanged.Invoke(health);
    }
    public static void SendBottleBroken(int brokenCount)
    {
        onBottleBroken.Invoke(brokenCount);
    }
    public static void SendBottleCollected(int scoreValue, int collectedCount)
    {
        onBottleCollected.Invoke(scoreValue, collectedCount);
    }
    public static void SendGameOver()
    {
        onGameOver.Invoke();
    }
}
