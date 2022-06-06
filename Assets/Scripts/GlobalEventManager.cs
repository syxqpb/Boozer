using UnityEngine.Events;

internal class GlobalEventManager
{
    public static UnityEvent<int> onWaveEnded = new UnityEvent<int>();
    public static void SendWaveEnded(int waveCount)
    {
        onWaveEnded.Invoke(waveCount);
    }
}
