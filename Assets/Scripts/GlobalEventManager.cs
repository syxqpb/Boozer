using UnityEngine.Events;

internal class GlobalEventManager
{
    public static UnityEvent<int> onWaveEnded = new UnityEvent<int>();
    public static UnityEvent bottleBroken = new UnityEvent();
    public static void SendWaveEnded(int waveCount)
    {
        onWaveEnded.Invoke(waveCount++);
    }
    public static void SendBottleBroken()
    {
        bottleBroken.Invoke();
    }
}
