using UnityEngine.Events;

[System.Serializable]
internal class GlobalEventManager : UnityEvent<GlobalEventManager>
{
    public static UnityEvent<int> onWaveEnded = new UnityEvent<int>();
    public static UnityEvent<int> onBottleCollected = new UnityEvent<int>();
    public static UnityEvent<int> onBottleBroken = new UnityEvent<int>();
    public static void SendWaveEnded(int waveCount)
    {
        onWaveEnded.Invoke(waveCount);
    }
    public static void SendBottleBroken(int brokenCount)
    {
        onBottleBroken.Invoke(brokenCount);
    }
    public static void SendBottleCollected(int collectedCount)
    {
        onBottleBroken.Invoke(collectedCount);
    }
}
